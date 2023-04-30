using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Conveyors {
    public class SpawnDestinations : MonoBehaviour {
        public List<GameObject> destinationsSpawns;
        public Destination destinationPrefab;
        public LayerMask m_LayerMask;
        private readonly float durationBetweenSpawn = 5f;

        [field: SerializeField] private string[] DestinationNames;

        public List<Destination> listDestinations { get; private set; }

        // Start is called before the first frame update
        private void Start() {
            listDestinations = new();
            this.StartCoroutine(this.SpawnDestination());
        }


        private IEnumerator SpawnDestination() {
            List<string> destinationNames = Utils.Utils.Sample(this.DestinationNames, this.destinationsSpawns.Count);
            while (this.destinationsSpawns.Count > 0) {
                GameObject destinationPos = Utils.Utils.Sample(this.destinationsSpawns);
                Destination newDestination = Instantiate(
                    this.destinationPrefab,
                    destinationPos.transform.position,
                    destinationPos.transform.rotation
                );
                newDestination.transform.SetParent(this.transform);
                newDestination.SetDestinationName(destinationNames[0]);
                destinationNames.RemoveAt(0);

                listDestinations.Add(newDestination);

                this.DestroyWalls(newDestination.gameObject);

                this.destinationsSpawns.Remove(destinationPos);

                yield return new WaitForSeconds(this.durationBetweenSpawn);
            }
        }

        private void DestroyWalls(GameObject _obj) {
            Collider[] hitColliders = Physics.OverlapBox(
                _obj.transform.position,
                _obj.transform.localScale / 2,
                Quaternion.identity,
                this.m_LayerMask
            );

            int i = 0;
            while (i < hitColliders.Length) {
                _obj.transform.rotation = hitColliders[i].gameObject.transform.rotation;
                Destroy(hitColliders[i].gameObject);
                i++;
            }
        }
    }
}
