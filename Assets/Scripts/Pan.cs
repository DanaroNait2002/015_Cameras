using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [Header("Vectors")]
    [SerializeField] private Vector3 locationOrigin;

    [Header("Timer")]
    [SerializeField] private float timer;

    private void Start()
    {
        locationOrigin = transform.position;
    }

    private void Update()
    {
        
    }
}
