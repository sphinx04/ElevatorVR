using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float seeRadius;
    public float walkRadius;
    public float attackRadius;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > seeRadius)
        {
            nav.enabled = false;
            nav.speed = 0;
            gameObject.GetComponent<Animator>().SetTrigger("idle");
        }
        if (dist <= seeRadius & dist > walkRadius)
        {
            nav.enabled = true;
            nav.speed = speed * 2.2f;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("run");
            gameObject.GetComponent<Animator>().ResetTrigger("idle");
            gameObject.GetComponent<Animator>().ResetTrigger("attack");
        }
        if (dist <= walkRadius & dist > attackRadius)
        { 
            nav.enabled = true; 
            nav.speed = speed; 
            nav.SetDestination(player.transform.position); 
            gameObject.GetComponent<Animator>().SetTrigger("walk"); 
            gameObject.GetComponent<Animator>().ResetTrigger("attack"); 
            gameObject.GetComponent<Animator>().ResetTrigger("run"); 
        } 
        if (dist <= attackRadius)
        {
            nav.enabled = false;
            nav.speed = 0;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            gameObject.GetComponent<Animator>().ResetTrigger("walk");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arrow")
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
} 
