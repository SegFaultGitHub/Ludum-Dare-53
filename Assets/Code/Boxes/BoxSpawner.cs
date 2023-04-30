using Code.Destinations;
using Code.Extensions;
using UnityEngine;

namespace Code.Boxes {
    public class SpawnerBox : MonoBehaviour {
        [field: SerializeField] private float SpawnInterval = 3f;
        [field: SerializeField] private Box BoxPrefab;
        [field: SerializeField] private bool Enabled;
        [field: SerializeField] private Transform SpawnPosition;
        [field: SerializeField] private Transform BoxesParent;
        [field: SerializeField] private DestinationManager DestinationManager;

        private void Start() => this.SpawnBox();

        private void SpawnBox() {
            if (this.Enabled) {
                Box box = Instantiate(this.BoxPrefab, this.SpawnPosition.position, Quaternion.identity);
                box.transform.SetParent(this.BoxesParent);
                box.SetDestination(this.DestinationManager.GetRandomDestination());
            }

            this.InSeconds(this.SpawnInterval, this.SpawnBox);
        }
    }
}
