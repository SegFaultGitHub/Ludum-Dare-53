using System;
using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using Code.UI;
using UnityEngine;

namespace Code.Conveyors {
    public enum Mode {
        Placement,
        Edition,
        Destruction,
        Camera
    }

    public class ConveyorsManager : WithRaycast {
        [field: SerializeField] private LayerMask ConveyorLayer;
        [field: SerializeField] private LayerMask ConveyorPlaneLayer;
        [field: SerializeField] private LayerMask GroundPlaneLayer;

        [field: SerializeField] private Conveyor ConveyorPrefab;
        [field: SerializeField] private Conveyor PhantomConveyor;

        private Vector3 CameraVelocity;
        private Vector2 CameraAngleVelocity;

        [field: SerializeField] private Mode Mode;
        private Conveyor Conveyor;
        private Dictionary<Vector2Int, Conveyor> Conveyors;
        private Direction Direction;
        private Vector3 DragPositionStart;
        private LTDescr EnablePhantomTween, MovePhantomTween;
        private Mode MasterMode;
        private bool ModeLocked;
        private bool PhantomEnabled;
        private Vector2Int PhantomPosition;

        protected override void Start() {
            base.Start();
            this.Conveyors = new Dictionary<Vector2Int, Conveyor>();
            this.NewPhantom();
        }

        private void Update() {
            this.GatherInputs();

            if (this.Input.SwitchToDestruction) {
                this.MasterMode = Mode.Destruction;
                this.SwitchMode(Mode.Destruction);
            } else if (this.Input.SwitchToEdition) {
                this.MasterMode = Mode.Edition;
                this.SwitchMode(Mode.Edition);
            } else if (this.Input.SwitchToPlacement) {
                this.MasterMode = Mode.Placement;
                this.SwitchMode(Mode.Placement);
            } else if (this.Input.SwitchToCamera) {
                this.MasterMode = Mode.Camera;
                this.SwitchMode(Mode.Camera);
            }

            switch (this.Mode) {
                case Mode.Placement:
                    this.PlacementBehaviour();
                    break;
                case Mode.Edition:
                    this.EditionBehaviour();
                    break;
                case Mode.Destruction:
                    this.DestructionBehaviour();
                    break;
                case Mode.Camera:
                    this.CameraBehaviour();
                    break;
                default:
                    throw new Exception($"[ConveyorsRayCast:Update] Unexpected mode {this.Mode}");
            }
        }

        private void SwitchMode(Mode mode) {
            if (this.Mode == mode) return;

            this.Mode = mode;

            switch (this.Mode) {
                case Mode.Placement:
                    if (this.Conveyor != null) this.Conveyor.HideArrow();
                    this.NewPhantom();
                    break;
                case Mode.Edition:
                    if (this.Conveyor != null) this.Conveyor.HideArrow();
                    this.HidePhantom();
                    if (this.PhantomConveyor != null)
                        this.Until(() => this.EnablePhantomTween == null, () => Destroy(this.PhantomConveyor.gameObject));
                    break;
                case Mode.Destruction:
                case Mode.Camera:
                    if (this.Conveyor != null) this.Conveyor.HideArrow();
                    this.HidePhantom();
                    if (this.PhantomConveyor != null)
                        this.Until(() => this.EnablePhantomTween == null, () => Destroy(this.PhantomConveyor.gameObject));
                    break;
                default:
                    throw new Exception($"[ConveyorsManager:SwitchMode] Unexpected mode {this.Mode}");
            }
        }

        private void PlacementBehaviour() {
            if (this.Input.DragPerformed && this.PhantomEnabled) {
                this.Conveyor = this.PhantomConveyor;
                this.Conveyor.ShowArrow();
                this.Conveyor.GridPosition = this.PhantomPosition;
                this.Mode = Mode.Edition;
                this.EditionBehaviour();
                return;
            }

            Hit<Plane>? hit = this.Raycast<Plane>(this.GroundPlaneLayer);

            if (hit == null) {
                this.HidePhantom();
                return;
            }

            Vector3 point = hit.Value.RaycastHit.point;
            if (point.x < 0) point.x -= 1;
            if (point.z < 0) point.z -= 1;
            Vector2Int position = new((int)(point.x + .5f), (int)(point.z + .5f));
            if (!this.ValidPosition(this.PhantomConveyor, this.PhantomConveyor.Direction, position)) {
                this.HidePhantom();
                return;
            }

            point = new Vector3(position.x, 0, position.y);
            this.ShowPhantom(point);

            if (position == this.PhantomPosition) return;

            if (this.MovePhantomTween != null) LeanTween.cancel(this.MovePhantomTween.id);
            this.MovePhantomTween = LeanTween.move(this.PhantomConveyor.gameObject, point, 0.05f)
                .setEaseOutQuad()
                .setOnComplete(() => this.MovePhantomTween = null);
            this.PhantomPosition = position;
        }

        private void EditionBehaviour() {
            Hit<Conveyor>? hit = this.Raycast<Conveyor>(this.ConveyorLayer);
            if (this.Input.DragPerformed && this.Conveyor != null) {
                Hit<Plane>? planeHit = this.Raycast<Plane>(this.ConveyorPlaneLayer);
                if (planeHit == null) throw new Exception("[ConveyorsRayCast:EditionBehaviour] No plane hit");
                this.DragPositionStart = planeHit.Value.RaycastHit.point;
            } else if (this.Input.DragInProgress && this.Conveyor != null) {
                Hit<Plane>? planeHit = this.Raycast<Plane>(this.ConveyorPlaneLayer);
                if (planeHit == null) throw new Exception("[ConveyorsRayCast:EditionBehaviour] No plane hit");
                Vector3 diff = this.DragPositionStart - planeHit.Value.RaycastHit.point;
                if (diff.magnitude > .5f) {
                    float angle = Vector3.SignedAngle(diff, Vector3.left, Vector3.up);
                    Direction direction = angle switch {
                        >= -45 and <= 45 => Direction.Right,
                        >= 45 and <= 135 => Direction.Up,
                        >= 135 or <= -135 => Direction.Left,
                        <= -45 and >= -135 => Direction.Down,
                        _ => this.Direction
                    };
                    if (this.ValidPosition(this.Conveyor, direction, this.Conveyor.GridPosition))
                        this.Conveyor.MockRotate(direction);
                }
            } else if (this.Input.DragEnded && this.Conveyor != null) {
                this.Conveyor.ApplyRotation();
                this.Direction = this.Conveyor.Direction;
                this.Place(this.Conveyor);
                this.Conveyor.HideArrow();
                this.Conveyor.SetPhantom(false);
                this.Conveyor = null;
                this.SwitchMode(this.MasterMode);
            } else if (hit != null) {
                if (hit.Value.Obj != this.Conveyor) {
                    if (this.Conveyor != null) this.Conveyor.HideArrow();
                    this.Conveyor = hit.Value.Obj;
                    this.Conveyor.ShowArrow();
                }
            } else if (this.Conveyor != null) {
                if (this.Conveyor != null) this.Conveyor.HideArrow();
                this.Conveyor = null;
            }
        }

        private void DestructionBehaviour() {
            Hit<Conveyor>? hit = this.Raycast<Conveyor>(this.ConveyorLayer);
            if (this.Input.DragPerformed && hit != null) this.DestroyConveyor(hit.Value.Obj);
        }

        private void CameraBehaviour() {
            if (this.Input.MoveCameraInProgress)
                this.MoveCamera();
            else if (this.Input.RotateCameraInProgress)
                this.RotateCamera();

            void _MoveCamera() {
                if (this.CameraVelocity.sqrMagnitude == 0)
                    return;
                this.Camera.transform.position += this.CameraVelocity;
                this.CameraVelocity *= 0.95f;
                if (this.CameraVelocity.magnitude < 0.001f)
                    this.CameraVelocity *= 0;
            }
            void _RotateCamera() {
                if (this.CameraAngleVelocity.sqrMagnitude == 0)
                    return;
                Vector3 angles = this.Camera.transform.eulerAngles;
                angles.y += this.CameraAngleVelocity.x * 1.5f;
                angles.x -= this.CameraAngleVelocity.y * 1.5f;
                angles.x = Mathf.Clamp(angles.x, 25, 75);
                this.Camera.transform.eulerAngles = angles;
                this.CameraAngleVelocity *= 0.95f;
                if (this.CameraAngleVelocity.magnitude < 0.001f)
                    this.CameraAngleVelocity *= 0;
            }

            _MoveCamera();
            _RotateCamera();
        }

        private bool ValidPosition(Conveyor conveyor, Direction direction, Vector2Int position) {
            List<Vector2Int> gridPositions = conveyor.GetGridPositions(position, direction);
            return gridPositions.Select(gridPosition => this.Conveyors.GetValueOrDefault(gridPosition, null))
                .All(c => c == null || c == conveyor);
        }

        private void Place(Conveyor conveyor) {
            List<Vector2Int> gridPositions = this.Conveyors.Keys.Where(k => this.Conveyors[k] == conveyor).ToList();
            foreach (Vector2Int gridPosition in gridPositions) {
                this.Conveyors.Remove(gridPosition);
            }
            conveyor.GetGridPositions(conveyor.GridPosition).ForEach(p => this.Conveyors[p] = conveyor);
        }

        private void DestroyConveyor(Conveyor conveyor) {
            List<Vector2Int> gridPositions = this.Conveyors.Keys.Where(k => this.Conveyors[k] == conveyor).ToList();
            foreach (Vector2Int gridPosition in gridPositions) {
                this.Conveyors.Remove(gridPosition);
            }
            conveyor.SetPhantom(true);
            LeanTween.scale(conveyor.gameObject, Vector3.zero, 0.15f).setEaseInBack().setDestroyOnComplete(true);
        }

        private void ShowPhantom(Vector3 position) {
            if (this.PhantomEnabled)
                return;
            this.PhantomEnabled = true;
            if (this.EnablePhantomTween == null) this.PhantomConveyor.transform.position = position;
            if (this.EnablePhantomTween != null) LeanTween.cancel(this.EnablePhantomTween.id);
            if (this.PhantomConveyor == null) return;
            this.EnablePhantomTween = LeanTween.scale(this.PhantomConveyor.gameObject, Vector3.one, 0.15f)
                .setEaseOutBack()
                .setOnComplete(() => this.EnablePhantomTween = null);
        }

        private void HidePhantom() {
            if (!this.PhantomEnabled)
                return;
            this.PhantomEnabled = false;
            if (this.EnablePhantomTween != null) LeanTween.cancel(this.EnablePhantomTween.id);
            if (this.PhantomConveyor == null) return;
            this.EnablePhantomTween = LeanTween.scale(this.PhantomConveyor.gameObject, Vector3.zero, 0.15f)
                .setEaseInBack()
                .setOnComplete(() => this.EnablePhantomTween = null);
        }

        private void NewPhantom() {
            this.PhantomConveyor = Instantiate(this.ConveyorPrefab, this.transform);
            this.PhantomConveyor.EditorRotate(this.Direction);
            this.PhantomConveyor.SetPhantom(true);
            this.PhantomEnabled = false;
            this.PhantomPosition = Vector2Int.zero;
            this.PhantomConveyor.transform.localScale *= 0;
            this.EnablePhantomTween = null;
            this.MovePhantomTween = null;
        }

        private void MoveCamera() {
            Vector2 delta = Quaternion.Euler(0, 0, -this.Camera.transform.eulerAngles.y) * this.MousePositionDelta / 60;
            this.CameraVelocity = new Vector3(-delta.x, 0, -delta.y);
        }

        private void RotateCamera() {
            this.CameraAngleVelocity = -this.MousePositionDelta / 30;
        }

        #region Input
        [Serializable]
        private class _Input {
            public bool DragEnded;
            public bool DragInProgress;
            public bool DragPerformed;
            public bool SwitchToPlacement;
            public bool SwitchToEdition;
            public bool SwitchToDestruction;
            public bool SwitchToCamera;
            // Camera
            public bool MoveCameraPerformed;
            public bool MoveCameraInProgress;
            public bool MoveCameraEnded;
            // --
            public bool RotateCameraPerformed;
            public bool RotateCameraInProgress;
            public bool RotateCameraEnded;
        }
        private _Input Input = new();

        protected override void OnEnable() {
            base.OnEnable();
            this.InputActions.Conveyors.Enable();
            this.InputActions.Camera.Enable();
            this.Input = new _Input {
                DragEnded = false,
                DragInProgress = false,
                DragPerformed = false,
                SwitchToPlacement = false,
                SwitchToEdition = false,
                SwitchToDestruction = false,
                SwitchToCamera = false,
                // Camera
                MoveCameraPerformed = false,
                MoveCameraInProgress = false,
                MoveCameraEnded = false,
                RotateCameraPerformed = false,
                RotateCameraInProgress = false,
                RotateCameraEnded = false
            };
        }

        protected override void OnDisable() {
            base.OnDisable();
            this.InputActions.Conveyors.Disable();
            this.InputActions.Camera.Disable();
        }

        protected override void GatherInputs() {
            base.GatherInputs();
            this.Input = new _Input {
                DragPerformed = this.InputActions.Conveyors.Drag.WasPerformedThisFrame(),
                DragInProgress = this.Input.DragInProgress,
                DragEnded = this.InputActions.Conveyors.Drag.WasReleasedThisFrame(),
                SwitchToPlacement = this.InputActions.Conveyors.ModePlacement.WasPerformedThisFrame(),
                SwitchToEdition = this.InputActions.Conveyors.ModeEdition.WasPerformedThisFrame(),
                SwitchToDestruction = this.InputActions.Conveyors.ModeDestruction.WasPerformedThisFrame(),
                SwitchToCamera = this.InputActions.Conveyors.ModeCamera.WasPerformedThisFrame(),
                // Camera
                MoveCameraPerformed = this.InputActions.Camera.MoveCamera.WasPerformedThisFrame(),
                MoveCameraInProgress = this.Input.MoveCameraInProgress,
                MoveCameraEnded = this.InputActions.Camera.MoveCamera.WasReleasedThisFrame(),
                // --
                RotateCameraPerformed = this.InputActions.Camera.RotateCamera.WasPerformedThisFrame(),
                RotateCameraInProgress = this.Input.RotateCameraInProgress,
                RotateCameraEnded = this.InputActions.Camera.RotateCamera.WasReleasedThisFrame(),
            };

            if (this.Input.DragPerformed)
                this.Input.DragInProgress = true;
            if (this.Input.DragEnded)
                this.Input.DragInProgress = false;

            if (this.Input.MoveCameraPerformed)
                this.Input.MoveCameraInProgress = true;
            if (this.Input.MoveCameraEnded)
                this.Input.MoveCameraInProgress = false;

            if (this.Input.RotateCameraPerformed)
                this.Input.RotateCameraInProgress = true;
            if (this.Input.RotateCameraEnded)
                this.Input.RotateCameraInProgress = false;
        }
        #endregion
    }
}
