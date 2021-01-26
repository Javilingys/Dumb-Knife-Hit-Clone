using KnifeHitClone.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2f;

        private Rigidbody2D rigidBody = null;
        /// <summary>
        /// If player launched knife = true.
        /// </summary>
        private bool wasLaunch = false;
        /// <summary>
        /// If Knife hitted something = true
        /// </summary>
        private bool isHit = false;

        #region Unity Functions
        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LaunchKnife();
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
            StopKnife();
            gameObject.transform.SetParent(wheel);
        }
        #endregion

        #region Private Finctions
        /// <summary>
        /// Start vertical mover of our knife
        /// </summary>
        private void LaunchKnife()
        {
            // If knife already was launched - return
            if (wasLaunch == true) return;
            // Set vertical speed of our knife
            rigidBody.velocity = new Vector2(0f, Vector2.up.y * speed);
            // Mark knife as launched
            wasLaunch = true;
        }

        /// <summary>
        /// Set velocity to zero ,set isKinematic as true and also set isHit = true
        /// </summary>
        public void StopKnife()
        {
            if (wasLaunch && !isHit)
            {
                rigidBody.velocity = Vector2.zero;
                rigidBody.isKinematic = true;
                // Stop knife also if knife hit something, therefore set isHit = true
                isHit = true;
            }
        }

        #endregion
    }
}