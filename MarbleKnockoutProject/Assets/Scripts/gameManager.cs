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
    public bool gamePlaying { get; private set; }
    public SpawnManager spawn;
    public Timer timer;
   
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
   
    
    private void EndGame()
    {
        gamePlaying = false;
       // Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {
        //add code later
    }
}
