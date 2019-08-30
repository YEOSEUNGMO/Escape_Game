using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    GameObject PressKey = null;

    void Start()
    {
        PressKey = transform.Find("Start").gameObject;
        StartCoroutine(Delay_OnOff());
    }

    void Update()
    {
        if (Input.anyKeyDown)
            Application.LoadLevel("Main");
    }

    IEnumerator Delay_OnOff()
    {
        while (true)
        {
            PressKey.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            Debug.Log("11");
            PressKey.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("22");

        }
    }
}
