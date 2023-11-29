using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Vector3 general;
    [SerializeField] private Vector3 generalRotation;
    [SerializeField] private Vector3 thirdPerson;

    [Header("Timer")]
    [SerializeField] private float timer;

    [Header("Bools")]
    [SerializeField] private bool isTranstioning;
    [SerializeField] private bool inGeneral;
    [SerializeField] private bool inThirdPerson;

    [Header("Character")]
    [SerializeField] private GameObject character;


    private void Start()
    {
        general = transform.position;
        generalRotation = transform.rotation.eulerAngles;

        timer = 10f;

        isTranstioning = false;
        inGeneral = true;
        inThirdPerson = false;
    }

    private void Update()
    {
        thirdPerson = new Vector3(character.transform.position.x + 0.5f, character.transform.position.y + 1f, character.transform.position.z - 1.5f);

        if (Input.GetKeyUp(KeyCode.Space) && !isTranstioning)
        {
            isTranstioning = true;

            if (inGeneral)
            {
                LeanTween.move(gameObject, thirdPerson, timer).setEase(LeanTweenType.easeInOutQuad);
                LeanTween.rotate(gameObject, thirdPerson, timer).setEase(LeanTweenType.easeInOutQuad).setOnComplete(CompleteGeneral);
            }
            if (inThirdPerson)
            {
                LeanTween.move(gameObject, general, timer).setEase(LeanTweenType.easeInOutQuad);
                LeanTween.rotate(gameObject, generalRotation, timer).setEase(LeanTweenType.easeInOutQuad).setOnComplete(CompleteThird);
            }
        }
        
    }

    private void CompleteGeneral()
    {
        inGeneral = false;
        inThirdPerson = true;

        isTranstioning = false;
    }
    private void CompleteThird()
    {
        inGeneral = true;
        inThirdPerson = false;

        isTranstioning = false;
    }
}
