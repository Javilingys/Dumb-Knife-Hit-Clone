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
        private bool wasLaunch = false;
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tags.WHEEL))
            {
                StopKnife();
                HitWheel(collision.gameObject.transform);
            }
        }
        #endregion

        #region Public Finctions
        #endregion

        #region Private Finctions
        private void LaunchKnife()
        {
            if (wasLaunch == true) return;
            rigidBody.velocity = new Vector2(0f, Vector2.up.y * speed);
            wasLaunch = true;
        }

        private void StopKnife()
        {
            if (wasLaunch && !isHit)
            {
                rigidBody.velocity = Vector2.zero;
                rigidBody.isKinematic = true;
                isHit = true;
            }
        }

        private void HitWheel(Transform wheel)
        {
            gameObject.transform.SetParent(wheel);
        }
        #endregion
    }
}