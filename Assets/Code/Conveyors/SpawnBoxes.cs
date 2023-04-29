using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors
{
    public class SpawnBoxes : MonoBehaviour
    {

        public List<Box> listOfBoxes;
        private float spawnSpeed = 2f;
        private float destroyDelay = 6f;

    // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnBox());
        }

        // Update is called once per frame
        void Update()
        {

        }


        private IEnumerator SpawnBox()
        {
            while (true)
            {
                Box boxToCreate = Utils.Utils.Sample(listOfBoxes);
                Box newBox = Instantiate(boxToCreate, transform.position, transform.rotation);
                Destroy(newBox.gameObject, destroyDelay);

                yield return new WaitForSeconds(spawnSpeed);
            }
        }
    }
}
