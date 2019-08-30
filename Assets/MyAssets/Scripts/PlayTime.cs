using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayTime : MonoBehaviour {

    private Text timeLabel;
    static public float timeCount = 0;
    public GameObject countDown;
    public bool timerOn;
    void Start()
    {
        timeLabel = GetComponent<Text>();
        timerOn = false;

    }

    void Update() {
        timeLabel.text = string.Format("{0:N2}", timeCount);
        
        
        if (timerOn)
        {
            timeCount += Time.deltaTime;
            
        }
	}
    
    public void reStart()
    {
        timeCount = 0;
    }
}
