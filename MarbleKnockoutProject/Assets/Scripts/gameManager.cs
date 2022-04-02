using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
    public AudioSource[] musicList;
   
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

        countdownDisplay.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            if(countdownTime == 3)
                musicList[7].Play();

            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        BeginGame();
        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        musicList[1].Play();
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
