using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Vector3 general;
    [SerializeField] private Vector3 generalRotation;
    [SerializeField] private Vector3 thirdPerson;

    /*[Header("Rotation")]
    [SerializeField] private Vector3 rotationOrigin;
    [SerializeField] private Vector3 rotationEnd;*/

    [Header("Timer")]
    [SerializeField] private float timer;

    [Header("Bools")]
    [SerializeField] private bool isTranstioning;
    [SerializeField] private bool inGeneral;
    [SerializeField] private bool inThirdPerson;
    [SerializeField] private bool canMove;

    [Header("Character")]
    [SerializeField] private GameObject character;


    private void Start()
    {
        general = transform.position;
        generalRotation = transform.rotation.eulerAngles;

        //thirdPerson = new Vector3(character.transform.position.x + 0.5f, character.transform.position.y + 1f, character.transform.position.z - 1.5f);

        timer = 10f;

        isTranstioning = false;
        inGeneral = true;
        inThirdPerson = false;
        canMove = false;
    }

    private void Update()
    {
        thirdPerson = new Vector3(character.transform.position.x + 0.5f, character.transform.position.y + 1f, character.transform.position.z - 1.5f);

        if (Input.GetKeyUp(KeyCode.Space) && !isTranstioning)
        {
            canMove = false;

            isTranstioning = true;

            Debug.Log("TRANSITIONING");

            if (inGeneral)
            {
                LeanTween.move(gameObject, thirdPerson, timer).setEase(LeanTweenType.easeInOutQuad);
                LeanTween.rotate(gameObject, thirdPerson, timer).setEase(LeanTweenType.easeInOutQuad).setOnComplete(CompleteGeneral);

                Debug.Log("TRANSITIONING GENERAL");
            }
            if (inThirdPerson)
            {
                LeanTween.move(gameObject, general, timer).setEase(LeanTweenType.easeInOutQuad);
                LeanTween.rotate(gameObject, generalRotation, timer).setEase(LeanTweenType.easeInOutQuad).setOnComplete(CompleteThird);

                Debug.Log("TRANSITIONING THIRD");
            }
        }

        
        if(canMove)
        {
            gameObject.transform.position = thirdPerson;
        }
        
    }

    private void CompleteGeneral()
    {
        inGeneral = false;
        inThirdPerson = true;

        isTranstioning = false;

        Debug.Log("COMPLETE GENERAL");
    }
    private void CompleteThird()
    {
        inGeneral = true;
        inThirdPerson = false;
        canMove = true;

        isTranstioning = false;

        Debug.Log("COMPLETE THIRD");
    }
}
