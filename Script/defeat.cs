using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeat : MonoBehaviour
{
    public GameObject defeatPanel;
    public AudioSource HAHAHAHA;
    public bool kalah;
    // Start is called before the first frame update
    void Start()
    {
        defeatPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().StunActive == false)
            {
                defeatPanel.SetActive(true);
                HAHAHAHA.Play();
                kalah = true;
                Time.timeScale = 0;
            }
        }
    }
}
