using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {

    public float walkSpeed;
    public float runSpeed;
    public GameObject player;
    public Transform[] wayPoint;
    bool targetPlayer = false;
    int index = 0;
    NavMeshAgent nav;
    Animator animator;
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        nav.speed = walkSpeed;
        animator.SetFloat("Speed", 0.1f);
        
    }
	
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if ((targetPlayer||distance < 5)&&(!player.GetComponent<Player>().hide))
        {
            targetPlayer = true;
            nav.speed = runSpeed;
            nav.SetDestination(player.transform.position);
            animator.SetFloat("Speed", nav.velocity.magnitude);
        }
        else
        {
            targetPlayer = false;
            nav.speed = walkSpeed;
            nav.SetDestination(wayPoint[index].position);
            animator.SetFloat("Speed", 0.1f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!targetPlayer)
        {
            if (other.transform.name == "wayPoint01")
            {
                index = 1;
                nav.SetDestination(wayPoint[index].position);
            }
            else if (other.transform.name == "wayPoint02")
            {
                index = 0;
                nav.SetDestination(wayPoint[index].position);
            }
        }
    }
}
