using System.Collections.Generic;
using Code.Destinations;
using Code.Extensions;
using TMPro;
using UnityEngine;

namespace Code.Boxes {
    public class BoxSpawner : MonoBehaviour {
        [field: SerializeField] protected float SpawnInterval = 3f;
        [field: SerializeField] protected Box BoxPrefab;
        [field: SerializeField] protected bool Enabled;
        [field: SerializeField] protected List<Transform> SpawnPositions;
        [field: SerializeField] private Transform BoxesParent;
        [field: SerializeField] private DestinationManager DestinationManager;

        // Initial delay
        [field: SerializeField] private float InitialDelay;
        [field: SerializeField] private TMP_Text CountdownText;
        private float Elapsed;

        private void Start() => this.InSeconds(this.InitialDelay, this.SpawnBox);

        private void Update() {
            if (this.Elapsed > this.InitialDelay) return;

            int seconds = (int) Mathf.Max(Mathf.Floor(this.InitialDelay - this.Elapsed), 0);

            if (this.CountdownText != null) this.CountdownText.text = $"{seconds}";
            this.Elapsed += Time.deltaTime;

            if (this.Elapsed >= this.InitialDelay && this.CountdownText != null) this.CountdownText.text = "--";
        }

        protected virtual void SpawnBox() {
            if (this.Enabled && this.DestinationManager.Ready) {
                Box box = Instantiate(this.BoxPrefab, Utils.Utils.Sample(this.SpawnPositions).position, Quaternion.identity);
                box.transform.SetParent(this.BoxesParent);
                box.SetDestination(this.DestinationManager.GetRandomDestination());
            }

            this.InSeconds(this.SpawnInterval, this.SpawnBox);
        }

        public void Disable() => this.Enabled = false;
    }
}
