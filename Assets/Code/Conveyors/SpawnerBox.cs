using Code.Boxes;
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
        [SerializeField] private Transform parentBoxes;
        [SerializeField] private SpawnDestinations spawnDestinations;


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
                if (spawnDestinations.listDestinations != null && spawnDestinations.listDestinations.Count != 0)
                {
                    Box newBox = Instantiate(boxPrefab, spawnPos.position, spawnPos.rotation);
                    newBox.SetDestination(Utils.Utils.Sample(this.spawnDestinations.listDestinations));

                    newBox.transform.parent = parentBoxes.transform;
                }

                yield return new WaitForSeconds(speedSpawn);
            }
        }
    }
}
