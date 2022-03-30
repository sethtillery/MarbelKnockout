using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 10f;
    public Text timeText;
    

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
            timeValue -= Time.deltaTime;
        else
        {
            timeValue += 11;
        }

        if(!GameObject.FindGameObjectWithTag("player1") || !GameObject.FindGameObjectWithTag("player2"))
        {
            timeValue = 10;
        }
        DisplayTime(timeValue);
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}", seconds);
        }
}
