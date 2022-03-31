using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 10f;
    public Text timeText;
    public gameManager manager;
    public SpawnManager spawn;

    private void Start()
    {
        timeText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (manager.gamePlaying && !spawn.decrementTime)
        {
            if (timeValue > 0)
                timeValue -= Time.deltaTime;
            else
            {
                timeValue += 11;
            }

            DisplayTime(timeValue);
        }
        
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
