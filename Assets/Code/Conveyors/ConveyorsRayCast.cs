using System;
using Code.UI;
using UnityEngine;

namespace Code.Conveyors {
    public class ConveyorsRayCast : WithRaycast {
        [field: SerializeField] private LayerMask ConveyorLayer;
        [field: SerializeField] private LayerMask ConveyorPlaneLayer;
        private Conveyor Conveyor;
        private Vector3 DragPositionStart;

        protected override void Update() {
            base.Update();
            this.GatherInput();

            Hit<Conveyor>? hit = this.Raycast<Conveyor>(this.ConveyorLayer);
            if (this.Input.DragPerformed && this.Conveyor != null) {
                Hit<ConveyorPlane>? planeHit = this.Raycast<ConveyorPlane>(this.ConveyorPlaneLayer);
                if (planeHit == null) throw new Exception("[ConveyorsRayCast:Update] No plane hit");
                this.DragPositionStart = planeHit.Value.RaycastHit.point;
            } else if (this.Input.DragInProgress && this.Conveyor != null) {
                Hit<ConveyorPlane>? planeHit = this.Raycast<ConveyorPlane>(this.ConveyorPlaneLayer);
                if (planeHit == null) throw new Exception("[ConveyorsRayCast:Update] No plane hit");
                Vector3 diff = this.DragPositionStart - planeHit.Value.RaycastHit.point;
                if (diff.magnitude > .5f) {
                    float angle = Vector3.SignedAngle(diff, Vector3.left, Vector3.up);
                    switch (angle) {
                        case >= -45 and <= 45:
                            this.Conveyor.MockRotate(Direction.Right);
                            break;
                        case >= 45 and <= 135:
                            this.Conveyor.MockRotate(Direction.Up);
                            break;
                        case >= 135 or <= -135:
                            this.Conveyor.MockRotate(Direction.Left);
                            break;
                        case <= -45 and >= -135:
                            this.Conveyor.MockRotate(Direction.Down);
                            break;
                    }
                }
            } else if (this.Input.DragEnded && this.Conveyor != null) {
                this.Conveyor.ApplyRotation();
            } else if (hit != null) {
                if (hit.Value.Obj != this.Conveyor) {
                    if (this.Conveyor != null) this.Conveyor.HideArrows();
                    this.Conveyor = hit.Value.Obj;
                    this.Conveyor.ShowArrows();
                }
            } else if (this.Conveyor != null) {
                if (this.Conveyor != null) this.Conveyor.HideArrows();
                this.Conveyor = null;
            }
        }

        #region Input
        private class _Input {
            public bool DragEnded;
            public bool DragInProgress;
            public bool DragPerformed;
        }
        private _Input Input = new();

        protected override void OnEnable() {
            base.OnEnable();
            this.InputActions.Conveyors.Enable();
            this.Input = new _Input {
                DragEnded = false,
                DragInProgress = false,
                DragPerformed = false
            };
        }

        protected override void OnDisable() {
            base.OnDisable();
            this.InputActions.Conveyors.Disable();
        }

        private void GatherInput() {
            this.Input = new _Input {
                DragPerformed = this.InputActions.Conveyors.Drag.WasPerformedThisFrame(),
                DragInProgress = this.Input.DragInProgress,
                DragEnded = this.InputActions.Conveyors.Drag.WasReleasedThisFrame()
            };

            if (this.Input.DragPerformed)
                this.Input.DragInProgress = true;
            if (this.Input.DragEnded)
                this.Input.DragInProgress = false;
        }
        #endregion
    }
}
