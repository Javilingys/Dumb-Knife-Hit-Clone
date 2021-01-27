using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeHitClone.Game
{
    [RequireComponent(typeof(Knife)), RequireComponent(typeof(Collider2D))]
    public class KnifeCollisionDetector : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<Knife> OnWheelCollision { get; set; }

        private Knife knife;

        private void Awake()
        {
            knife = GetComponent<Knife>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.WHEEL) && !knife.IsHit)
            {
                OnWheelCollision?.Invoke(knife);
            }
        }
    }
}