using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
    
    private int n;

    void Update () {
        if(GameObject.Find("PlayTime").GetComponent<PlayTime>().timerOn)
            Opening();
	}

    private void Opening()
    {

        if (n < 90)
        {
            n++;
            Vector3 Ang = gameObject.transform.eulerAngles;

            Ang.y += 1.0f;

            gameObject.transform.eulerAngles = Ang;
        }
    }
}
