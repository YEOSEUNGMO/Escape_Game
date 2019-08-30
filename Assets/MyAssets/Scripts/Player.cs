using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool hide=false;
    CharacterController cc;
    public float moveSpeed;
    Animator animator;
    public bool gameOver = false;

	void Start () {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        if (!gameOver)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (direction.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp(transform.forward, direction, 0.1f);
                transform.LookAt(transform.position + forward);
            }
            cc.Move(direction * moveSpeed * Time.deltaTime);
            animator.SetFloat("Speed", cc.velocity.magnitude);
        }
        animator.SetBool("GameOver", gameOver);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bush")
        {
            hide = !hide;
        }
        else if (other.transform.tag == "NPC")
        {
            GameObject.Find("PlayTime").GetComponent<PlayTime>().timerOn = false;
            Application.LoadLevel("GameOver");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Bush")
        {
            hide = !hide;
        }
        else if (other.transform.name == "Ending")
        {
            Application.LoadLevel("Ending");
        }
    }
}
