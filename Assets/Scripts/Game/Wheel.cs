using System;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField]
    private WheelData wheelData; // TODO: set outside (delete SerializeField)
    [Header("Prefabs")]
    [SerializeField]
    private Transform knifePrefab;
    [SerializeField]
    private Transform applePrefab;

    private List<Knife> knifes;

    private void Awake()
    {
        knifes = new List<Knife>();
    }

    private void Start()
    {
        SpawnApple();
    }

    private void SpawnApple()
    {
        
    }

    private void Update()
    {

    }

    private void RotateWheel()
    {
        transform.Rotate(new Vector3(0, 0, wheelData.speed * Time.deltaTime));
    }
}
