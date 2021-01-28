using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class KnifeRigidBodyHandler : MonoBehaviour
    {
        [Header("Die paramteres")]
        [SerializeField]
        [Tooltip("Force for push knife when he collides with another knife, or when wheel is destroy")]
        private float force;
        [SerializeField]
        private float torqgue;

        [Header("Launch Parameters")]
        [SerializeField]
        private float launchSpeed = 30f;

        private Vector2 forceDirction;
        private Rigidbody2D rb;

        public Rigidbody2D RigiBody { get => rb; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void LaunchKnife()
        {
            RigiBody.AddForce(Vector2.up * launchSpeed, ForceMode2D.Impulse);
        }

        public void StopKnife()
        {
            RigiBody.isKinematic = true;
            RigiBody.velocity = Vector2.zero;
        }

        public void ForceBehaviour(Vector2 forceDir)
        {
            forceDirction = forceDir;

            rb.isKinematic = false;
            rb.velocity = Vector2.zero;

            float randTorque = Random.Range(-100, 100);

            forceDirction = forceDirction.normalized;

            torqgue += randTorque;

            rb.mass = 4;
            rb.gravityScale = 1.2f;

            rb.AddForce(forceDirction * force, ForceMode2D.Impulse);
            rb.AddTorque(torqgue);


            Destroy(gameObject, 1.5f);
        }
    }
}