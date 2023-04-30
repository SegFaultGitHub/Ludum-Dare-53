using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using UnityEngine;

namespace Code.Destinations {
    public class DestinationManager : MonoBehaviour {
        private List<Destination> Destinations;
        private List<Destination> EnabledDestinations;
        private const float IntervalDuration = 5f;
        public bool Ready => this.EnabledDestinations.Count > 0;

        private static readonly string[] DestinationNames = {
            "Athens",
            "Berlin",
            "Brussels",
            "Budapest",
            "Copenhagen",
            "Dublin",
            "Helsinki",
            "Ljubljana",
            "London",
            "Minsk",
            "Oslo",
            "Paris",
            "Prague",
            "Reykjavík",
            "Riga",
            "Rome",
            "Sarajevo",
            "Sofia",
            "Tallinn",
            "Tirana",
            "Vienna",
            "Warsaw",
            "Zagreb"
        };

        private void Start() {
            this.Destinations = this.GetComponentsInChildren<Destination>().ToList();
            this.EnabledDestinations = new List<Destination>();
            List<string> destinationNames = Utils.Utils.Sample(DestinationNames, this.Destinations.Count);
            this.EnableDestination(destinationNames);
        }

        private void EnableDestination(IList<string> destinationNames) {
            Destination destination = Utils.Utils.Sample(this.Destinations);
            this.EnabledDestinations.Add(destination);
            this.Destinations.Remove(destination);
            destination.Enable();
            destination.SetDestinationName(destinationNames[0]);
            destinationNames.RemoveAt(0);

            if (this.Destinations.Count > 0) this.InSeconds(IntervalDuration, () => this.EnableDestination(destinationNames));
        }

        public Destination GetRandomDestination() {
            return Utils.Utils.Sample(this.EnabledDestinations);
        }

        public void Disable() {
            this.EnabledDestinations.ForEach(d => d.Disable());
        }
    }
}
