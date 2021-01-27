using KnifeHitClone.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private float speed = 30f;

        private Rigidbody2D myRigidBody;
        private bool isReleased;
        private bool isHit;

        public bool IsReleased { get => isReleased; set => isReleased = value; }
        public bool IsHit { get => isHit; set => isHit = value; }

        private void Awake()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LaunchKnife();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.WHEEL) && !IsHit)
            {
                collision.GetComponent<Wheel>().KnifeHit(this);
            }
            else if (collision.CompareTag(Tags.APPLE))
            {
                collision.GetComponent<Apple>().KnifeHit(this);
            }
        }

        public void StopKnife()
        {
            myRigidBody.isKinematic = true;
            myRigidBody.velocity = Vector2.zero;
            isHit = true;
        }

        private void LaunchKnife()
        {
            if (!isReleased && !isHit)
            {
                isReleased = true;
                myRigidBody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            }
        }
    }
}