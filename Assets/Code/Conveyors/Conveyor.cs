using System;
using UnityEngine;

namespace Code {
    public enum Direction {
        Up, Down, Left, Right
    }
    public class Conveyor : MonoBehaviour {
        [field: SerializeField] private bool Locked;
        [field: SerializeField] private Direction Direction;
        [field: SerializeField] private Direction DisplayedDirection;
        [field: SerializeField] private GameObject Arrows;

        private LTDescr RotateTween;

        // True when there is a box on the conveyor
        private bool Occupied;

        private void Awake() {
            ParticleSystem[] particles = this.Arrows.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particle in particles) {
                ParticleSystem.Burst burst = particle.emission.GetBurst(0);
                burst.probability = 0;
                particle.emission.SetBurst(0, burst);
            }
        }

        public void HideArrows() {
            ParticleSystem[] particles = this.Arrows.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particle in particles) {
                ParticleSystem.Burst burst = particle.emission.GetBurst(0);
                burst.probability = 0;
                particle.emission.SetBurst(0, burst);
            }
        }

        public void ShowArrows() {
            ParticleSystem[] particles = this.Arrows.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particle in particles) {
                ParticleSystem.Burst burst = particle.emission.GetBurst(0);
                burst.probability = 1;
                particle.emission.SetBurst(0, burst);
            }
        }

        public void MockRotate(Direction direction) {
            if (this.Locked || this.Occupied || this.DisplayedDirection == direction) return;

            this.DisplayedDirection = direction;

            if (this.RotateTween != null) LeanTween.cancel(this.RotateTween.id);
            float angle = direction switch {
                Direction.Up => -90,
                Direction.Down => 90,
                Direction.Left => 180,
                Direction.Right => 0,
                _ => throw new Exception($"[Conveyor:Rotate] Unexpected direction {direction}")
            };

            this.RotateTween = LeanTween.rotateY(this.gameObject, angle, 0.1f).setEaseInBack().setOnComplete(() => this.RotateTween = null);
        }

        public void ApplyRotation() {
            if (this.Locked || this.Occupied) {
                this.MockRotate(this.Direction);
                return;
            }

            this.Direction = this.DisplayedDirection;
            this.MockRotate(this.Direction);
        }
    }
}
