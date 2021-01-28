using KnifeHitClone.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    [RequireComponent(typeof(KnifeRigidBodyHandler))]
    public class Knife : MonoBehaviour
    {
        public event Action OnRelease;
        public event Action OnWheelHit;

        private KnifeRigidBodyHandler rigidBodyHandler;
        private bool isReleased;
        private bool isHit;

        public bool IsReleased { get => isReleased; set => isReleased = value; }
        public bool IsHit { get => isHit; set => isHit = value; }

        private void Awake()
        {
            rigidBodyHandler = GetComponent<KnifeRigidBodyHandler>();
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
                OnWheelHit?.Invoke();
            }
            else if (collision.CompareTag(Tags.APPLE))
            {
                collision.GetComponent<Apple>().KnifeHit(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tags.KNIFE) && !IsHit)
            {
                IsHit = true;
                rigidBodyHandler.ForceBehaviour(new Vector2(UnityEngine.Random.Range(-1f, 1f), -1f));
            }
        }

        public void StopKnife()
        {
            rigidBodyHandler.StopKnife();
            isHit = true;
        }

        private void LaunchKnife()
        {
            if (!isReleased && !isHit)
            {
                isReleased = true;
                rigidBodyHandler.LaunchKnife();
            }
        }

        public void ForceBehaviour(Vector2 forceDir)
        {
            rigidBodyHandler.ForceBehaviour(forceDir);
        }
    }
}