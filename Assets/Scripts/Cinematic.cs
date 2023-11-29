using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    [Header("Vectors")]
    [SerializeField] private Vector3[] locations;
    [SerializeField] private Vector3[] rotations;
    [SerializeField] private int value;

    [Header("Timers")]
    [SerializeField] private float timer;

    #region VERTIGO 

    [Header("FOV")]
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;

    [Header("Vectors")]
    [SerializeField] private Vector3 locationOrigin;
    [SerializeField] private Vector3 locationEnd;

    [Header("Timer")]
    [SerializeField] private float timerFOV;

    [Header("Camera")]
    [SerializeField] Camera cam;

    #endregion

    private void Start()
    {
        LeanTween.init(3000);

        value = 1;
    }

    private void Update()
    {
        if (value >= 0 && value <= locations.Length && value <= rotations.Length)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (value == locations.Length && value == rotations.Length)
                {
                    DoVertigoEffect();
                }

                else if (value >= 0 && value < locations.Length && value < rotations.Length)
                {
                    LeanTween.move(gameObject, locations[value], 10f).setEase(LeanTweenType.easeInOutQuad);
                    LeanTween.rotate(gameObject, rotations[value], 10f).setEase(LeanTweenType.easeInOutQuad);
                }

                timer = 10f;
                value++;
            }
        }
    }

    private void DoVertigoEffect()
    {
        LeanTween.move(gameObject, locationEnd, timerFOV).setEase(LeanTweenType.easeInOutSine);
        LeanTween.value(gameObject, minFOV, maxFOV, timerFOV).setEase(LeanTweenType.easeInOutSine).setOnUpdate(UpdateFOV).setOnComplete(OnVertigoComplete);
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
