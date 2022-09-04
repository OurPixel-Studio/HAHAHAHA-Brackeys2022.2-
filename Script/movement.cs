using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public int player;
    [Space]
    public GameObject card1, card2, card3;
    [SerializeField]bool pickCard;
    [SerializeField]
    [Space]
    public CharacterController myController;
    [SerializeField]float speed = 10f;
    Vector3 velocity;
    Vector3 moveDir;
    public float gravity = -9.81f;
    [Space]
    
    [SerializeField]string ObjectName;
    [SerializeField]bool Area;

    [Space]
    public AudioSource StunSound;
    public bool StunActive;
    [SerializeField]float taserCD = 15;
    [SerializeField]bool taserReady;
    public AudioSource thirdRecorder;
    public AudioSource cardObtain;
    public AudioSource taserOn;
    public AudioSource taserTDK;

    public GameObject InteractUI;
    [Space]
    [Space]
    public int hasCard;
    void Start()
    {
        myController = GetComponent<CharacterController>();
        card1.SetActive(false);
        StartCoroutine(cardMuncul());
        hasCard = 1;
        Area = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        stunMachine();
    }

    void move()
    {

        if(player == 1)
        {
            transform.Rotate(0, Input.GetAxis("leftright") * 180 * Time.deltaTime, 0);
            moveDir = new Vector3(0, 0, Input.GetAxis("updown"));
            moveDir = transform.TransformDirection(moveDir);
            myController.Move(moveDir * speed * Time.deltaTime);

            velocity.y = gravity;
            myController.Move(velocity * Time.deltaTime);
        }
        if(player == 2)
        {
            transform.Rotate(0, Input.GetAxis("AD") * 180 * Time.deltaTime, 0);
            moveDir = new Vector3(0, 0, Input.GetAxis("WS"));
            moveDir = transform.TransformDirection(moveDir);
            myController.Move(moveDir * speed * Time.deltaTime);

            velocity.y = gravity;
            myController.Move(velocity * Time.deltaTime);
        }


    }

    void stunMachine()
    {
        taserCD -= 1 * Time.deltaTime;
        if(taserCD <= 0)
        {
            taserReady = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(taserReady == true)
            {
                taserOn.Play();
                StunActive = true;
                taserCD = 15;
                taserReady = false;
            }else
            {
                taserTDK.Play();
            }
        }

        if(StunActive == true)
        {
            StartCoroutine(StunTime());
        }
    }

    IEnumerator StunTime()
    {
        yield return new WaitForSeconds(6);
        StunActive = false;
    }

    IEnumerator cardMuncul()
    {
        yield return new WaitForSeconds(5);
        card1.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            InteractUI.SetActive(true);
            ObjectName = other.GetComponent<selectObject>().ObjectName;
            Area = true;

            if(Input.GetKeyDown(KeyCode.F))
            {
                thirdRecorder.Play();
            }
        }

        if(other.gameObject.CompareTag("card"))
        {
            InteractUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(hasCard > 0)
                {
                    card1.SetActive(false);
                    card2.SetActive(true);
                    hasCard = 2;
                    cardObtain.Play();
                }
                if(hasCard > 1)
                {
                    hasCard = 3;
                    card2.SetActive(false);
                    card3.SetActive(true);
                }
                if(hasCard > 2)
                {
                    hasCard = 4;
                    card3.SetActive(false);
                }
                InteractUI.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        InteractUI.SetActive(false);
        if(other.gameObject.CompareTag("Object"))
        {
            ObjectName = null;
            Area = false;
        }
    }
}
