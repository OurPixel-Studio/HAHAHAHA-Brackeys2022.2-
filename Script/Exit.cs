using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    Animator myAnim;
    [SerializeField]bool ready;
    public bool open;
    public GameObject Player;
    public GameObject F;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
            F.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<movement>().hasCard >= 3)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(ready == true)
                {
                    open = true;
                }
            }
        }else
        {
            if(ready == true)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("BELOM BISA EUY");
                }
            }
        }
        myAnim.SetBool("open", open);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ready = true;
            if(Player.GetComponent<movement>().hasCard >= 3){
                F.SetActive(true);
            }
        }
    }

    void OnTriggerExit()
    {
        F.SetActive(false);
    }
}

