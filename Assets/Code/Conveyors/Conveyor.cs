using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code {
    public enum Direction {
        Up, Down, Left, Right
    }

    public class Conveyor : MonoBehaviour {
        [field: SerializeField] private bool Locked;
        [field: SerializeField] private int Length;
        [field: SerializeField] public Direction Direction;
        [field: SerializeField] private Direction DisplayedDirection;
        [field: SerializeField] private GameObject Arrow;
        [field: SerializeField] private GameObject Models;
        [field: SerializeField] private GameObject MoveTrigger;
        [field: SerializeField] private GameObject PhysicsCollider;
        private Vector3 InitialArrowScale;
        public Vector2Int GridPosition { get; set; }

        private LTDescr RotateTween, ArrowTween;
        public bool Phantom { get; set; }

        private void Awake() {
            this.InitialArrowScale = this.Arrow.transform.localScale;
            this.Arrow.transform.localScale *= 0;
        }

        public void HideArrow() {
            if (this.ArrowTween != null) LeanTween.cancel(this.ArrowTween.id);
            float duration = this.Arrow.transform.localScale.x * 0.25f;
            this.ArrowTween = LeanTween.scale(this.Arrow, Vector3.zero, duration)
                .setEaseInBack()
                .setOnComplete(() => this.ArrowTween = null);
        }

        public void ShowArrow() {
            if (this.RotateTween != null) LeanTween.cancel(this.RotateTween.id);
            float duration = (this.InitialArrowScale.x - this.Arrow.transform.localScale.x) * 0.25f;
            this.ArrowTween = LeanTween.scale(this.Arrow, this.InitialArrowScale, duration)
                .setEaseOutBack()
                .setOnComplete(() => this.ArrowTween = null);
        }

        public void MockRotate(Direction direction) {
            if (this.Locked || this.DisplayedDirection == direction) return;

            this.DisplayedDirection = direction;

            if (this.RotateTween != null) LeanTween.cancel(this.RotateTween.id);
            float angle = GetRotation(direction);

            this.RotateTween = LeanTween.rotateY(this.Models, angle, 0.2f)
                .setEaseOutQuad()
                .setOnComplete(() => this.RotateTween = null);
        }

        public void ApplyRotation() {
            if (this.Locked) {
                this.MockRotate(this.Direction);
                return;
            }

            this.Direction = this.DisplayedDirection;
            this.MoveTrigger.transform.localEulerAngles = new Vector3(0, GetRotation(this.Direction), 0);
            this.PhysicsCollider.transform.localEulerAngles = new Vector3(0, GetRotation(this.Direction), 0);
            this.MockRotate(this.Direction);
        }

        public void EditorRotate(Direction direction) {
            this.Direction = direction;
            this.DisplayedDirection = direction;
            this.Models.transform.localEulerAngles = new Vector3(0, GetRotation(this.Direction), 0);
            this.MoveTrigger.transform.localEulerAngles = new Vector3(0, GetRotation(this.Direction), 0);
            this.PhysicsCollider.transform.localEulerAngles = new Vector3(0, GetRotation(this.Direction), 0);
        }

        public Vector3 GetForce() {
            return this.Direction switch {
                Direction.Up => new Vector3(0, 0, 1),
                Direction.Down => new Vector3(0, 0, -1),
                Direction.Left => new Vector3(-1, 0, 0),
                Direction.Right => new Vector3(1, 0, 0),
                _ => throw new Exception($"[Conveyor:ApplyForce] Unexpected direction {this.Direction}")
            };
        }

        public void SetPhantom(bool phantom) {
            if (this.Phantom == phantom) return;
            this.Phantom = phantom;

            if (this.Phantom) {
                this.MoveTrigger.SetActive(false);
                this.PhysicsCollider.SetActive(false);
            } else {
                this.MoveTrigger.SetActive(true);
                this.PhysicsCollider.SetActive(true);
            }
        }

        private static float GetRotation(Direction direction) {
            return direction switch {
                Direction.Up => -90,
                Direction.Down => 90,
                Direction.Left => 180,
                Direction.Right => 0,
                _ => throw new Exception($"[Conveyor:Rotate] Unexpected direction {direction}")
            };
        }
        public List<Vector2Int> GetGridPositions(Vector2Int position, Direction? direction = null) {
            List<Vector2Int> result = new();
            direction ??= this.Direction;
            Vector2Int lengthVector = direction switch {
                Direction.Up => new Vector2Int(0, 1),
                Direction.Down => new Vector2Int(0, -1),
                Direction.Left => new Vector2Int(-1, 0),
                Direction.Right => new Vector2Int(1, 0),
                _ => throw new Exception($"[Conveyor:GetPositions] Unexpected direction {direction}")
            };
            for (int i = 0; i < this.Length; i++) {
                result.Add(position + lengthVector * i);
            }
            return result;
        }
    }
}
