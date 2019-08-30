using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf_Walk : MonoBehaviour {
    public float walkSpeed;
    public Transform[] wayPoint;
    NavMeshAgent nav;

    void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = walkSpeed;
        nav.SetDestination(wayPoint[0].position);
    }
	
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "WayPoint")
        {
            nav.SetDestination(wayPoint[1].position);
        }
        else
            nav.SetDestination(wayPoint[0].position);
    }
}
