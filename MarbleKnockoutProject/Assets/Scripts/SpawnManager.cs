using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject safetyDome;
    private float spawnRange = 9;
    public GameObject powerUpPrefab;
    public Timer timer;
    GameObject killDome;
    GameObject killPlayer1;
    GameObject killPlayer2;
    public GameObject player1;
    public GameObject player2;
    public gameManager manager;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public int playerOneGameScore = 0;
    public int playerTwoGameScore = 0;
    public int domeCounter = 0;
    public Color[] colorList;
    public Image winScreenBackground;
    public Material[] materialList;
    public Material[] useMaterialList;
    public bool singlePlayer = true;
    public bool multiplayer = false;
    public Enemy enemy;


    // Start is called before the first frame update
    void Awake()
    {
        spawnPlayers();
        safetyDome.transform.localScale = new Vector3(14, 14, 14);
        enemy = player2.GetComponent<Enemy>();
    }

    IEnumerator waitToResetScene()
    {
   
       yield return  new WaitForSeconds(3);
       killPlayer1 = GameObject.FindGameObjectWithTag("player1");
       killPlayer2 = GameObject.FindGameObjectWithTag("player2");

       if (!killPlayer1 || !killPlayer2)
       {
            if (!killPlayer1)
            { 
                playerTwoScore++;

                if(playerTwoScore == manager.ScoreToWin)
                {
                    playerTwoGameScore++;
                    playerOneScore = 0;
                    playerTwoScore = 0;
                }

                if (playerTwoGameScore == manager.gamesToWin)
                {
                    if(player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[0])
                    {
                        winScreenBackground.material = materialList[0];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[1])
                    {
                        winScreenBackground.material = materialList[1];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[2])
                    {
                        winScreenBackground.material = materialList[2];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[3])
                    {
                        winScreenBackground.material = materialList[3];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[4])
                    {
                        winScreenBackground.material = materialList[4];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[5])
                    {
                        winScreenBackground.material = materialList[5];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player2.GetComponent<Renderer>().sharedMaterial == useMaterialList[6])
                    {
                        winScreenBackground.material = materialList[6];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }
                }

                Destroy(killPlayer2);
            }

            if (!killPlayer2)
            {
                playerOneScore++;

                if (playerOneScore == manager.ScoreToWin)
                {
                    playerOneGameScore++;
                    playerOneScore = 0;
                    playerTwoScore = 0;
                }

                if (playerOneGameScore == manager.gamesToWin)
                {
                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[0])
                    {
                        winScreenBackground.material = materialList[0];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[1])
                    {
                        winScreenBackground.material = materialList[1];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[2])
                    {
                        winScreenBackground.material = materialList[2];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[3])
                    {
                        winScreenBackground.material = materialList[3];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[4])
                    {
                        winScreenBackground.material = materialList[4];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[5])
                    {
                        winScreenBackground.material = materialList[5];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }

                    if (player1.GetComponent<Renderer>().sharedMaterial == useMaterialList[6])
                    {
                        winScreenBackground.material = materialList[6];
                        manager.musicList[1].Stop();
                        manager.musicList[6].Play();
                        manager.gamePlaying = false;
                        manager.showWinScreen = true;
                    }
                }

                Destroy(killPlayer1);
            }

            timer.timeValue = 11;
            domeCounter = 0;
            timer.decrementTime = true;
            safetyDome.transform.localScale = new Vector3(14, 14, 14);
            Destroy(killDome);
            spawnPlayers();

            if (singlePlayer)
            {
                GameObject.FindGameObjectWithTag("player2").GetComponent<Enemy>().enabled = true;
                GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerController1>().enabled = false;

            }
            else
            {
                GameObject.FindGameObjectWithTag("player2").GetComponent<Enemy>().enabled = false;
                GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerController1>().enabled = true;
            }
            enemy = GameObject.FindGameObjectWithTag("player2").GetComponent<Enemy>();
            enemy.player = GameObject.FindGameObjectWithTag("player1");

            spawnSafetyDome();
       }
    }
    // Update is called once per frame
    void Update()
    {
        if(killPlayer1)
        {
            enemy.player = GameObject.FindGameObjectWithTag("player1");
        }
        if(playerOneGameScore == 1 || playerTwoGameScore == 1)       
            manager.musicList[1].pitch = (float)1.5;
        
        if(playerOneGameScore == 2 && playerTwoGameScore == 2)      
            manager.musicList[1].pitch = 2;       

        if (playerOneGameScore == 3 && playerTwoGameScore == 3)        
            manager.musicList[1].pitch = 3;       

        if (!killPlayer1 || !killPlayer2)
        {
            resetScene();
        }

        killDome = GameObject.FindGameObjectWithTag("SafetyDome");

        if(timer.timeValue < 0.00001 && killPlayer1 && killPlayer2)
        {
            Destroy(killDome);
            spawnSafetyDome();
            if (domeCounter == 4 || domeCounter == 7)
            {
                SpawnPowerup();
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
    void SpawnPowerup()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

     public void spawnSafetyDome()
    { 
        Instantiate(safetyDome, GenerateSpawnPosition(), safetyDome.transform.rotation);
        safetyDome.transform.localScale -= new Vector3(2, 2, 2);
        domeCounter++;
    }

    void spawnPlayers()
    {
        Instantiate(player1, new Vector3(0, 0, 0), player1.transform.rotation);
        Instantiate(player2, new Vector3(0, 0, 6), player2.transform.rotation);
        enemy.player = GameObject.FindGameObjectWithTag("player1");
    }

    void resetScene()
    {
        StartCoroutine(waitToResetScene());
        
    }
}
