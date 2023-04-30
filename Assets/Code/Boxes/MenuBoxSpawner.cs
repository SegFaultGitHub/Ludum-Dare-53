using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Boxes {
    public class MenuSpawnBoxes : MonoBehaviour {

        public List<Box> listOfBoxes;
        private readonly float destroyDelay = 6f;
        private readonly float spawnSpeed = 2f;

        // Start is called before the first frame update
        private void Start() {
            this.StartCoroutine(this.SpawnBox());
        }

        // Update is called once per frame
        private void Update() { }


        private IEnumerator SpawnBox() {
            while (true) {
                Box boxToCreate = Utils.Utils.Sample(this.listOfBoxes);
                Box newBox = Instantiate(boxToCreate, this.transform.position, this.transform.rotation);
                Destroy(newBox.gameObject, this.destroyDelay);

                yield return new WaitForSeconds(this.spawnSpeed);
            }
        }
    }
}
