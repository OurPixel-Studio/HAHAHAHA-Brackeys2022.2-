using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField]int randomUrutan;
    public int jumlahRandomUrutan;
    public GameObject[] TempatRandom;
    // Start is called before the first frame update
    void Start()
    {
        randomUrutan = Random.Range(0, jumlahRandomUrutan);
        transform.position = TempatRandom[(randomUrutan)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
