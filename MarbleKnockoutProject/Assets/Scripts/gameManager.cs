using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public static gameManager instance;
    public bool gamePlaying;
    public bool showWinScreen = false;
    public SpawnManager spawn;
    public Timer timer;
    public int ScoreToWin;
    public int gamesToWin = 1;
    public bool twoSeries = false;
    public bool fourSeries = false;
   
    private float startTime, elapsedTime;
    TimeSpan timeplaying;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        instance = this;
        countdownDisplay.gameObject.SetActive(false);
    }

    public IEnumerator countdownToStart()
    {
        if (spawn.singlePlayer)
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<Enemy>().enabled = true;
            GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerController1>().enabled = false;

        }
        else
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<Enemy>().enabled = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerController1>().enabled = true;
        }

        countdownDisplay.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        BeginGame();
        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);


        timer.timeText.gameObject.SetActive(true);
        spawn.spawnSafetyDome();
        countdownDisplay.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePlaying = false;
        //StartCoroutine(countdownToStart());
    }
    
    public void BeginGame()
    {

        gamePlaying = true;
        startTime = Time.time;
    }
}
