using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent monster;
    public Transform player;

    [SerializeField]float hunting = 30f;    
    [SerializeField]bool targeting;

    [SerializeField]bool pindah;
    [SerializeField]int randomUrutan;
    public int jumlahRandomUrutan;
    public GameObject[] TempatRandom;
    [Space]
    [SerializeField]float speed;

    [Space]
    public Animator myAnim;
    [SerializeField]bool run;
    [SerializeField]bool idle;
    [SerializeField]bool Stun;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        pindah = true;
        Debug.Log(randomUrutan);
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.GetComponent<movement>().hasCard >= 3)
        {
            monster.speed = 6;
        }
        if(pindah == true)
        {
           randomUrutan = Random.Range(1, jumlahRandomUrutan);
           StartCoroutine(keliling());
        }
        if(targeting == true)
        {
            if(Player.GetComponent<movement>().hasCard >= 3)
            {
                monster.speed = 6;
            }else
            {
                monster.speed = 4;
            }
            monster.SetDestination(player.position);
        }
        
        if(randomUrutan == jumlahRandomUrutan)randomUrutan -= 1;

        if(targeting == false)
        {
            monster.speed = speed;
            monster.SetDestination(TempatRandom[(randomUrutan)].transform.position);
        }

        if(monster.remainingDistance > monster.stoppingDistance)
        {
            run = true;
            idle = false;
        }else
        {
            run = false;
            idle = true;
        }

        myAnim.SetBool("run", run);
        myAnim.SetBool("idle", idle);        

        Stunned();
    }

    void Stunned()
    {
        Stun = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().StunActive;

        if(Stun == true)
        {
            targeting = false;
            monster.SetDestination(transform.position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(Stun == false)
            {
                targeting = true; 
            }           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(bye());      
        }
    }

    IEnumerator keliling()
    {
        pindah = false;
        if(Player.GetComponent<movement>().hasCard >= 3)
        {
            yield return new WaitForSecondsRealtime(15);
        }else
        {
            yield return new WaitForSecondsRealtime(hunting);
        }
        pindah = true;
    }

    IEnumerator bye()
    {
        yield return new WaitForSecondsRealtime(5);
        targeting = false;
    }
}
