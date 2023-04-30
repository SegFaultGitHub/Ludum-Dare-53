using Code.Extensions;
using Quaternion = UnityEngine.Quaternion;

namespace Code.Boxes {
    public class MenuSpawnBoxes : BoxSpawner {
        protected override void SpawnBox() {
            if (this.Enabled) {
                Box box = Instantiate(this.BoxPrefab, Utils.Utils.Sample(this.SpawnPositions).position, Quaternion.identity);
                Destroy(box.gameObject, 3);
            }

            this.InSeconds(this.SpawnInterval, this.SpawnBox);
        }
    }
}
