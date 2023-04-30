using System.Collections.Generic;
using Code.Conveyors;
using Code.Destinations;
using UnityEngine;

namespace Code.Boxes {
    public class Box : MonoBehaviour {

        [field: SerializeField] private PhysicMaterial OnConveyorMaterial, OffConveyorMaterial;
        [field: SerializeField] private float MaxSpeed = 1f;

        [field: SerializeField] private BoxDestinationUI BoxDestinationUI;
        public Destination Destination { get; set; }
        private List<Conveyor> ActiveConveyors;
        private Rigidbody Rigidbody;
        private _State State;
        public bool Scored { get; set; }
        private float Ratio => this.MaxSpeed / 160;

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

        public void SetDestination(Destination destination) {
            this.Destination = destination;
            this.BoxDestinationUI.SetDestination(destination);
        }

        public void ShowDestination() => this.BoxDestinationUI.Open();
        public void HideDestination() => this.BoxDestinationUI.Close();


        private void AssignMaterial(PhysicMaterial material) {
            foreach (Collider collider in this.GetComponents<Collider>()) {
                collider.material = material;
            }
        }

        private enum _State {
            OnConveyor, OffConveyor, None
        }
    }
}
