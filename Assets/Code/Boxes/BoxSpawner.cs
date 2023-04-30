using System.Collections.Generic;
using Code.Destinations;
using Code.Extensions;
using UnityEngine;

namespace Code.Boxes {
    public class BoxSpawner : MonoBehaviour {
        [field: SerializeField] protected float SpawnInterval = 3f;
        [field: SerializeField] protected Box BoxPrefab;
        [field: SerializeField] protected bool Enabled;
        [field: SerializeField] protected List<Transform> SpawnPositions;
        [field: SerializeField] private Transform BoxesParent;
        [field: SerializeField] private DestinationManager DestinationManager;

        private void Start() => this.SpawnBox();

        protected virtual void SpawnBox() {
            if (this.Enabled && this.DestinationManager.Ready) {
                Box box = Instantiate(this.BoxPrefab, Utils.Utils.Sample(this.SpawnPositions).position, Quaternion.identity);
                box.transform.SetParent(this.BoxesParent);
                box.SetDestination(this.DestinationManager.GetRandomDestination());
            }

            this.InSeconds(this.SpawnInterval, this.SpawnBox);
        }
    }
}
