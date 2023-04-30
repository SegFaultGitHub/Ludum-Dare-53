using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Conveyors {
    public class Destination : MonoBehaviour {

        public ScoreManagement score;

        public GameObject door;
        public GameObject convoyers;
        public string DestinationName { get; set; }
        public TMP_Text destinationText;

        private readonly float destroyDelay = 3f;

        // Start is called before the first frame update
        private void Start() {
            this.score = GameObject.FindGameObjectWithTag("ScoreManagement").GetComponent<ScoreManagement>();

            this.OpenAnimation();
        }

        public void OnTriggerEnter(Collider collision) {
            if (collision.gameObject.CompareTag("Box")) {
                Box _box = collision.gameObject.GetComponent<Box>();

                if (_box.Destination == this) {
                    Debug.Log("Box delivered !");
                    this.score.AddScore(100);
                } else {
                    Debug.Log("Wrong destination !");
                    this.score.AddScore(-50);
                }

                Destroy(collision.gameObject, this.destroyDelay);
            }
        }

        private void OpenAnimation() {
            LeanTween.moveLocalY(this.door, this.door.transform.localPosition.y + 1.3f, 1f).setEaseOutBack();
            LeanTween.moveLocalZ(this.convoyers, this.convoyers.transform.localPosition.z - 1.5f, 1f).setEaseOutBack().setDelay(1);
        }
        public void SetDestinationName(string destinationName) {
            this.DestinationName = destinationName;
            this.destinationText.text = destinationName;
        }
    }
}
