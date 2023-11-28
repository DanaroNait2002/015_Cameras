using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Vector3 locationOrigin;
    [SerializeField] private Vector3 locationEnd;

    [Header("Rotation")]
    [SerializeField] private Vector3 rotationOrigin;
    [SerializeField] private Vector3 rotationEnd;

    [Header("Timer")]
    [SerializeField] private float timer;

    private void Start()
    {
        locationOrigin = new Vector3(7.78f, 4.21f, 9.27f);
        rotationOrigin = new Vector3(5f, -135f, 0.0f);

        locationEnd = new Vector3(-15.65f, 4.21f, 9.27f);
        rotationEnd = new Vector3(5f, 135f, 0.0f);

        timer = 10f;

        StarPan();
    }

    private void StarPan()
    {
        LeanTween.rotate(gameObject, rotationEnd, timer).setEase(LeanTweenType.easeInOutQuad);
    }
}
