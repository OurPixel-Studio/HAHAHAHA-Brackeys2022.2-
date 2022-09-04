using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    Animator myaAnim;
    [SerializeField]bool up;
    public GameObject f;
    // Start is called before the first frame update
    void Start()
    {
        myaAnim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(up == true)
        {
            f.SetActive(false);
            StartCoroutine(autoDown());
        }
        myaAnim.SetBool("up", up);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            f.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                up  = true;
            }
        }
    }

    IEnumerator autoDown(){
        yield return new WaitForSeconds(5);
        up=false;
    }
}
