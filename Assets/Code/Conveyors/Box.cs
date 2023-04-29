using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors {
    public class Box : MonoBehaviour {
        private Rigidbody Rigidbody;
        private List<Conveyor> ActiveConveyors;

        [field: SerializeField] private PhysicMaterial OnConveyorMaterial, OffConveyorMaterial;
        [field: SerializeField] private float MaxSpeed = 1f;
        private float Ratio => this.MaxSpeed / 20;

        private void Awake() {
            this.ActiveConveyors = new List<Conveyor>();
            this.Rigidbody = this.GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            if (this.ActiveConveyors.Count == 0) {
                this.OffConveyor();
            } else {
                this.OnConveyor();
            }
        }

        private void OnConveyor() {
            foreach (Conveyor conveyor in this.ActiveConveyors) {
                this.Rigidbody.velocity += conveyor.GetForce() * this.MaxSpeed * this.Ratio;
            }

            this.Rigidbody.velocity = Vector3.ClampMagnitude(this.Rigidbody.velocity, this.MaxSpeed);
        }

        private void OffConveyor() {
        }

        private void OnTriggerEnter(Collider other) {
            Conveyor conveyor = other.GetComponentInParent<Conveyor>();
            if (conveyor == null) return;
            this.ActiveConveyors.Add(conveyor);
        }

        private void OnTriggerExit(Collider other) {
            Conveyor conveyor = other.GetComponentInParent<Conveyor>();
            if (conveyor == null) return;
            this.ActiveConveyors.Remove(conveyor);
        }
    }
}
