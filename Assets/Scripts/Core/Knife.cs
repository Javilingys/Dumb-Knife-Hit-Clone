using KnifeHitClone.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Core
{
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2f;

        public Rigidbody2D rigidBody = null;
        /// <summary>
        /// If player launched knife = true.
        /// </summary>
        private bool isReleased = false;
        /// <summary>
        /// If Knife hitted something = true
        /// </summary>
        private bool isHit = false;

        public bool IsReleased { get => isReleased; set => isReleased = value; }
        public bool IsHit { get => isHit; set => isHit = value; }

        #region Unity Functions
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LaunchKnife();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.WHEEL) && !isHit)
            {
                HitWheel(collision.transform);
            }
            else if (collision.gameObject.CompareTag(Tags.KNIFE) && !isHit && IsReleased)
            {
                transform.SetParent(collision.transform);
                rigidBody.velocity = Vector2.zero;
                rigidBody.isKinematic = true;
            }
        }
        #endregion

        #region Public Finctions
        /// <summary>
        /// Stop Knife and set knife's parent a Wheel. Triggered on hiting the Wheel by CollisionDetector
        /// </summary>
        /// <param name="wheel">trnasform wheel for SetParent(wheel)</param>
        public void HitWheel(Transform wheel)
        {
            wheel.gameObject.GetComponent<Wheel>().KnifeHit(this);
        }
        #endregion

        #region Private Finctions
        /// <summary>
        /// Start vertical mover of our knife
        /// </summary>
        private void LaunchKnife()
        {
            // If knife already was launched - return
            if (IsReleased == true) return;
            // Set vertical speed of our knife
            rigidBody.AddForce(new Vector2(0, 1f * speed), ForceMode2D.Impulse);
            // Mark knife as launched
            IsReleased = true;
        }

        /// <summary>
        /// Set velocity to zero ,set isKinematic as true and also set isHit = true
        /// </summary>
        public void StopKnife()
        {
            if (IsReleased && !IsHit)
            {
                rigidBody.velocity = Vector2.zero;
                rigidBody.isKinematic = true;
                // Stop knife also if knife hit something, therefore set isHit = true
                IsHit = true;
            }
        }

        #endregion
    }
}