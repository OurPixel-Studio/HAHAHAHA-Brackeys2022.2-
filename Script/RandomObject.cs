using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    [SerializeField]bool pembukaan;
    public GameObject Robot;
    // Start is called before the first frame update
    void Start()
    {
        Robot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pembukaan == false)
        {
            StartCoroutine(Awal());
        }else
        {
            Robot.SetActive(true);
        }   


    }

    IEnumerator Awal()
    {
        yield return new WaitForSeconds(5);
        pembukaan = true;
    }
}
