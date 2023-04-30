using Code.UI;
using UnityEngine;

namespace Code.Conveyors {
    public class BoxesManager : WithRaycast {
        [field: SerializeField] private LayerMask BoxLayer;
        private Box Box;

        protected override void Update() {
            base.Update();

            Hit<Box>? hit = this.Raycast<Box>(this.BoxLayer);
            if (hit != null) {
                if (hit.Value.Obj != this.Box) {
                    if (this.Box != null) this.Box.ShowDestination();
                    this.Box = hit.Value.Obj;
                    this.Box.ShowDestination();
                }
            } else if (this.Box != null) {
                if (this.Box != null) this.Box.HideDestination();
                this.Box = null;
            }
        }
    }
}
