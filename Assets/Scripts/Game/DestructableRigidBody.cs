using KnifeHitClone.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class DestructableRigidBody : MonoBehaviour
{
    [SerializeField]
    private Vector2 forceDirction;
    [SerializeField]
    private float force;
    [SerializeField]
    private float torqgue;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ForceBehaviour();
    }

    private void ForceBehaviour()
    {
        float randTorque = Random.Range(-100, 100);
        float randForceX = Random.Range(forceDirction.x - 50, forceDirction.x + 50);
        float randForceY = Random.Range(forceDirction.y, forceDirction.x + 50);

        forceDirction.x = randForceX;
        forceDirction.y = randForceY;
        forceDirction = forceDirction.normalized;

        torqgue += randTorque;

        rb.AddForce(forceDirction * force, ForceMode2D.Impulse);
        rb.AddTorque(torqgue);

        // Depend on GameManager. It's bad, but it simple way for synchronize.
        Destroy(transform.parent.gameObject, GameManager.Instance.TimeToDestroyObjects);
    }
}
