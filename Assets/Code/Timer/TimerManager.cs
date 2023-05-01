using System.Collections.Generic;
using Code.Boxes;
using Code.Destinations;
using TMPro;
using UnityEngine;

namespace Code.Timer {
    public class TimerManager : MonoBehaviour {
        [field: SerializeField] private TMP_Text Text;
        [field: SerializeField] private float Duration;
        private float Elapsed;

        [field: SerializeField] private DestinationManager DestinationManager;
        [field: SerializeField] private List<BoxSpawner> Spawners;

        [field: SerializeField] private GameOverMenu GameOverMenu;

        private void Update() {
            if (this.Elapsed >= this.Duration) return;
            int minutes = (int) Mathf.Max(Mathf.Floor((this.Duration - this.Elapsed) / 60), 0);
            int seconds = (int) Mathf.Max(Mathf.Floor((this.Duration - this.Elapsed) % 60), 0);

            this.Text.text = $"{minutes:0}:{seconds:00}";
            this.Elapsed += Time.deltaTime;

            if (this.Elapsed >= this.Duration) {
                this.DestinationManager.Disable();
                this.Spawners.ForEach(s => s.Disable());

                this.GameOverMenu.GameOver();
            }
        }
    }
}
