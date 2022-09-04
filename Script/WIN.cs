using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
