using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors
{
    public class SpawnDestinations : MonoBehaviour
    {

        public List<GameObject> destinationsSpawns;
        private float durationBetweenSpawn = 5f;
        public GameObject destinationPrefab;

        public LayerMask m_LayerMask;

        public int numberOfDestination = 0;



        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnDestination());
        }

        // Update is called once per frame
        void Update()
        {

        }


        private IEnumerator SpawnDestination()
        {
            while (destinationsSpawns.Count > 0)
            {
                GameObject destinationPos = Utils.Utils.Sample(destinationsSpawns);
                GameObject newDestination = Instantiate(destinationPrefab, destinationPos.transform.position, destinationPos.transform.rotation);

                newDestination.gameObject.GetComponent<Destination>().destinationId = numberOfDestination++;

                DestroyWalls(newDestination);

                destinationsSpawns.Remove(destinationPos);

                yield return new WaitForSeconds(durationBetweenSpawn);
            }
        }

        private void DestroyWalls(GameObject _obj)
        {
            Collider[] hitColliders = Physics.OverlapBox(_obj.transform.position, _obj.transform.localScale / 2, Quaternion.identity, m_LayerMask);

            int i = 0;
            while (i < hitColliders.Length)
            {
                _obj.transform.rotation = hitColliders[i].gameObject.transform.rotation;
                Destroy(hitColliders[i].gameObject);
                i++;
            }
        }
    }
}
