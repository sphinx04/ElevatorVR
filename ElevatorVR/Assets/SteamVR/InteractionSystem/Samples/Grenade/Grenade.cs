using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Grenade : MonoBehaviour
    {
        public GameObject explodePartPrefab;
        public GameObject explodePrefab;
        public int explodeCount = 10;
        public float minMagnitudeToExplode = 1f;
        private Interactable interactable;

        private void Start()
        {
            interactable = this.GetComponent<Interactable>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (interactable != null && interactable.attachedToHand != null) //don't explode in hand
                return;

            if (collision.impulse.magnitude > minMagnitudeToExplode)
            {
                GameObject explosion = GameObject.Instantiate(explodePrefab, this.transform.position, this.transform.rotation);
                for (int explodeIndex = 0; explodeIndex < explodeCount; explodeIndex++)
                {
                    GameObject explodePart = GameObject.Instantiate(explodePartPrefab, this.transform.position, this.transform.rotation);
                }
                Destroy(this.gameObject);
            }
        }
    }
}