using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors
{
    public class SpawnerBox : MonoBehaviour
    {

        [SerializeField] private float speedSpawn = 3f;
        [SerializeField] private Box boxPrefab;
        [SerializeField] private bool spawnActivated = false;
        [SerializeField] private Transform spawnPos;


        // Start is called before the first frame update
        void Start()
        {
            spawnActivated = true;
            StartCoroutine(SpawnBox());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator SpawnBox()
        {
            while (spawnActivated)
            {
                Box newBox = Instantiate(boxPrefab, spawnPos.position, spawnPos.rotation);

                yield return new WaitForSeconds(speedSpawn);
            }
        }
    }
}
