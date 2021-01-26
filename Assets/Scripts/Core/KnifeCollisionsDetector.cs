using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeHitClone.Core
{
    [RequireComponent(typeof(Collider2D))]
    public class KnifeCollisionsDetector : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<Transform> onWheelHit { get; set; }
        [field: SerializeField]
        public UnityEvent onKnifeHit { get; set; }
        [field: SerializeField]
        public UnityEvent onAppleHit { get; set; }

        private Collider2D myCollider;

        private void Awake()
        {
            myCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.WHEEL))
            {
                onWheelHit?.Invoke(collision.gameObject.transform);
            }
        }
    }
}