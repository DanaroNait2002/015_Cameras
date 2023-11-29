using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotationOrigin; //por si vuelve en loop
    [SerializeField] private Vector3 rotationEnd;

    [Header("Timer")]
    [SerializeField] private float timer;

    private void Start()
    {
        rotationOrigin = new Vector3(5f, -135f, 0.0f);

        rotationEnd = new Vector3(5f, 135f, 0.0f);

        timer = 10f;

        StarPan();
    }

    private void StarPan()
    {
        LeanTween.rotate(gameObject, rotationEnd, timer).setEase(LeanTweenType.easeInOutQuad);
    }
}
