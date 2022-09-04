using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
             activeCam.Priority = 0; 
        }
    }
}
