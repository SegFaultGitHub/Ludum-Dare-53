using Code.UI;
using TMPro;
using UnityEngine;

namespace Code.Conveyors {
    public class BoxDestinationUI : MonoBehaviour, IWithWorldCanvas {
        [field: SerializeField] private Canvas Canvas;
        [field: SerializeField] private TMP_Text Text;
        private LTDescr Tween;

        private void Awake() {
            this.Canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            this.Canvas.gameObject.SetActive(false);
            this.Canvas.transform.localScale *= 0;
        }

        private void Update() {
            ((IWithWorldCanvas)this).RotateCanvas(this.Canvas);
        }

        public void SetDestination(Destination destination) {
            this.Text.text = destination.DestinationName;
        }

        public void Open() {
            if (this.Tween != null) LeanTween.cancel(this.Tween.id);

            this.Canvas.gameObject.SetActive(true);
            float duration = 1 - this.Canvas.transform.localScale.x;
            this.Tween = LeanTween.scale(this.Canvas.gameObject, Vector3.one, duration * 0.25f)
                .setEaseOutBack()
                .setOnComplete(() => this.Tween = null);
        }

        public void Close() {
            if (!this.Canvas.gameObject.activeSelf)
                return;

            if (this.Tween != null) LeanTween.cancel(this.Tween.id);

            float duration = this.Canvas.transform.localScale.x;
            this.Tween = LeanTween.scale(this.Canvas.gameObject, Vector3.zero, duration * 0.25f)
                .setEaseInBack()
                .setOnComplete(
                    () => {
                        this.Canvas.gameObject.SetActive(false);
                        this.Tween = null;
                    }
                );
        }
    }
}
