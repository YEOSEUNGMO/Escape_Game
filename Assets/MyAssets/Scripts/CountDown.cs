using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    private Text timeLabel;
    private float count = 5.5f;
    void Start()
    {
        timeLabel = GetComponent<Text>();
        GameObject.Find("PlayTime").GetComponent<PlayTime>().reStart();
    }
	void Update () {
        count -= Time.deltaTime;
        timeLabel.text = string.Format("{0:N0}", count);
        if (count < 1.0f && count > 0.0f)
        {
            GameObject.Find("PlayTime").GetComponent<PlayTime>().timerOn = true;
            timeLabel.text = "START!!";
        }
        else if (count <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
