using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject[] camCode;
    GameObject player;
    int nomor;
    // pemanggilan array => cek camera.txt

    [Space]
    [SerializeField] int roomCode;
    //roomcode juga cek camera.txt
    // Start is called before the first frame update
    void Start()
    {
        for(int a = 1; a<=37; a++)
        {
            if(a == 1)
            {
                continue;
            }       
            camCode[a].SetActive(false);
        }
        camCode[1].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        nomor = player.GetComponent<movement>().player;

        if(nomor == 1)
        {
            this.GetComponent<Camera>().rect = new Rect(0,0, 0.5f, 1);
        }
        if(nomor == 2)
        {
            this.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(nomor == 1)
            {
                this.GetComponent<Camera>().rect = new Rect(0,0, 0.5f, 1);
            }
            if(nomor == 2)
            {
                this.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1);
            }
        }
        if(other.gameObject.CompareTag("room"))
        {
            roomCode = other.GetComponent<rooms>().roomcode;

            for(int a = 1; a<=37; a++)
            {
                if(a == roomCode)
                {
                    continue;
                }       
                camCode[a].SetActive(false);
            }

            camCode[roomCode].SetActive(true);            
        }
    }
}
