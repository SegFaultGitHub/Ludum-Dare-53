using Code.UI;
using UnityEngine;

namespace Code.Boxes {
    public class BoxesManager : WithRaycast {
        [field: SerializeField] private LayerMask BoxLayer;
        private Box Box;

        private void Update() {
            this.GatherInputs();

            Hit<Box>? hit = this.Raycast<Box>(this.BoxLayer);
            if (hit != null) {
                if (hit.Value.Obj != this.Box) {
                    if (this.Box != null) this.Box.HideDestination();
                    this.Box = hit.Value.Obj;
                    this.Box.ShowDestination();
                }
            } else if (this.Box != null) {
                this.Box.HideDestination();
                this.Box = null;
            }
        }
    }
}
