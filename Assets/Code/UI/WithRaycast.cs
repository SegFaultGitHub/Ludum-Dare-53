using UnityEngine;

namespace Code.UI {
    public abstract class WithRaycast : MonoBehaviour {

        private static readonly RaycastHit[] RAYCAST_HITS = new RaycastHit[10];

        protected Camera Camera;
        protected Vector2 MousePosition, MousePositionDelta;

        protected virtual void Start() {
            this.Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        protected Hit<T>? Raycast<T>(LayerMask layer) {
            for (int i = 0; i < RAYCAST_HITS.Length; i++) RAYCAST_HITS[i] = default;
            Physics.RaycastNonAlloc(this.Camera.ScreenPointToRay(this.MousePosition), RAYCAST_HITS, 1000, layer);

            float minDistance = float.MaxValue;
            RaycastHit? result = null;
            foreach (RaycastHit hit in RAYCAST_HITS) {
                if (hit.collider is null) break;
                if (hit.collider.GetComponentInParent<T>() == null) continue;
                if (minDistance < hit.distance) continue;

                minDistance = hit.distance;
                result = hit;
            }

            if (result == null) return null;
            return new Hit<T> {
                RaycastHit = result.Value,
                Obj = result.Value.collider.GetComponentInParent<T>()
            };
        }
        protected struct Hit<T> {
            public RaycastHit RaycastHit;
            public T Obj;
        }

        #region Input
        protected InputActions InputActions;

        protected virtual void OnEnable() {
            this.InputActions = new InputActions();
            this.InputActions.Globals.Enable();
        }

        protected virtual void OnDisable() {
            this.InputActions.Globals.Disable();
        }

        protected virtual void GatherInputs() {
            this.MousePositionDelta = this.MousePosition;
            this.MousePosition = this.InputActions.Globals.MousePosition.ReadValue<Vector2>();
            this.MousePositionDelta = this.MousePosition - this.MousePositionDelta;
        }
        #endregion
    }
}
