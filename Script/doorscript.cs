using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    Animator anim;
    [SerializeField] bool open;
    
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("open", open);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            open = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(itung());        
        }
    }

    IEnumerator itung()
    {
        if(open == true)
        {
            yield return new WaitForSeconds(3);
            open = false;
        }
    }
}
