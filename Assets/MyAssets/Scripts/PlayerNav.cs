using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNav : MonoBehaviour {
    public float Speed;
    public Transform[] wayPoint;
    int index = 0;
    int nextindex = 0;
    NavMeshAgent nav;
    Animator animator;

    void Start () {

        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        nav.speed = Speed;
        
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Speed", nav.velocity.magnitude);
        nav.SetDestination(wayPoint[index].position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform==wayPoint[index])
        {
            nextindex = Random.Range(0, 6);
            while (nextindex==index)
                nextindex = Random.Range(0, 6);
            index = nextindex;

        }
    }
}
