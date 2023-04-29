using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors {
    public class Box : MonoBehaviour {
        private Rigidbody Rigidbody;
        private List<Conveyor> ActiveConveyors;

        private enum _State {
            OnConveyor, OffConveyor, None
        }

        [field: SerializeField] private PhysicMaterial OnConveyorMaterial, OffConveyorMaterial;
        [field: SerializeField] private float MaxSpeed = 1f;
        private float Ratio => this.MaxSpeed / 160;
        private _State State;

        private void Awake() {
            this.ActiveConveyors = new List<Conveyor>();
            this.Rigidbody = this.GetComponent<Rigidbody>();
            this.State = _State.None;
        }

        private void FixedUpdate() {
            _State previousState = this.State;
            if (this.ActiveConveyors.Count == 0) {
                this.State = _State.OffConveyor;
                this.OffConveyor(previousState);
            } else {
                this.State = _State.OnConveyor;
                this.OnConveyor(previousState);
            }
        }

        private void OnConveyor(_State previousState) {
            if (previousState != _State.OnConveyor) this.AssignMaterial(this.OnConveyorMaterial);
            foreach (Conveyor conveyor in this.ActiveConveyors) {
                this.Rigidbody.velocity += conveyor.GetForce() * this.MaxSpeed * this.Ratio;
            }

            this.Rigidbody.velocity = Vector3.ClampMagnitude(this.Rigidbody.velocity, this.MaxSpeed);
        }

        private void OffConveyor(_State previousState) {
            if (previousState != _State.OffConveyor) this.AssignMaterial(this.OffConveyorMaterial);
        }

        private void OnTriggerEnter(Collider other) {
            Conveyor conveyor = other.GetComponentInParent<Conveyor>();
            if (conveyor == null) return;
            this.ActiveConveyors.Add(conveyor);
        }

        private void AssignMaterial(PhysicMaterial material) {
            foreach (Collider collider in this.GetComponents<Collider>()) {
                collider.material = material;
            }
        }

        private void OnTriggerExit(Collider other) {
            Conveyor conveyor = other.GetComponentInParent<Conveyor>();
            if (conveyor == null) return;
            this.ActiveConveyors.Remove(conveyor);
        }
    }
}
