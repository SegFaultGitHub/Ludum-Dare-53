using Code.Boxes;
using TMPro;
using UnityEngine;

namespace Code.Destinations {
    public class Destination : MonoBehaviour {
        private ScoreManagement ScoreManagement;
        [field: SerializeField] private GameObject Door;
        [field: SerializeField] private GameObject Conveyors;
        [field: SerializeField] private TMP_Text DestinationText;
        public string DestinationName { get; set; }
        public bool Enabled { get; set; }

        private void Start() {
            this.ScoreManagement = GameObject.FindGameObjectWithTag("ScoreManagement").GetComponent<ScoreManagement>();
            this.SetDestinationName("");
        }

        public void Enable() {
            this.Enabled = true;
            LeanTween.moveLocalY(this.Door, this.Door.transform.localPosition.y + 1.3f, 1f).setEaseOutBack();
            LeanTween.moveLocalZ(this.Conveyors, this.Conveyors.transform.localPosition.z - 1.5f, 1f).setEaseOutBack().setDelay(1);
        }

        public void SetDestinationName(string destinationName) {
            this.DestinationName = destinationName;
            this.DestinationText.text = destinationName;
        }

        private void OnTriggerEnter(Collider collision) {
            Box box = collision.gameObject.GetComponent<Box>();
            if (box == null) return;

            this.ScoreManagement.AddScore(box.Destination == this ? 100 : -50);
            LeanTween.scale(box.gameObject, Vector3.zero, .5f).setDelay(1).setDestroyOnComplete(true);
        }
    }
}
