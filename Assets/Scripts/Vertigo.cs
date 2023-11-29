using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertigo : MonoBehaviour
{
    [Header("FOV")]
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;

    [Header("Vectors")]
    [SerializeField] private Vector3 locationOrigin;
    [SerializeField] private Vector3 locationEnd;

    [Header("Timer")]
    [SerializeField] private float timer;

    [Header("Camera")]
    [SerializeField] Camera cam;

    private void Start()
    {
        cam.fieldOfView = minFOV;

        timer = 10f;

        cam = GetComponent<Camera>();
        DoVertigoEffect();
    }

    private void DoVertigoEffect()
    {
        LeanTween.move(gameObject, locationEnd, timer).setEase(LeanTweenType.easeInOutSine);
        LeanTween.value(gameObject, minFOV, maxFOV, timer).setEase(LeanTweenType.easeInOutSine).setOnUpdate(UpdateFOV).setOnComplete(OnVertigoComplete);
    }

    private void UpdateFOV(float fov)
    {
        cam.fieldOfView = fov;
    }

    private void OnVertigoComplete()
    {
        cam.fieldOfView = maxFOV;
    }
}
