using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Awake()
    {
        spawnPlayers();
        safetyDome.transform.localScale = new Vector3(14, 14, 14);
        spawnSafetyDome();    
    }

    IEnumerator waitToResetScene()
    {
        yield return  new WaitForSeconds(3);
    }
    // Update is called once per frame
    void Update()
    {
        resetScene();

        killDome = GameObject.FindGameObjectWithTag("SafetyDome");

        if(timer.timeValue < 0.00001)
        {
            Destroy(killDome);
            spawnSafetyDome();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
        // code missing here
    }
    void SpawnPowerup()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void spawnSafetyDome()
    { 
        Instantiate(safetyDome, GenerateSpawnPosition(), safetyDome.transform.rotation);
        safetyDome.transform.localScale -= new Vector3(2, 2, 2);
    }

    void spawnPlayers()
    {
        Instantiate(player1, new Vector3(0, 0, 0), player1.transform.rotation);
        Instantiate(player2, new Vector3(0, 0, 6), player2.transform.rotation);
    }

    void resetScene()
    {
        StartCoroutine(waitToResetScene());
       killPlayer1 = GameObject.FindGameObjectWithTag("player1");
       killPlayer2 = GameObject.FindGameObjectWithTag("player2");

       if (!killPlayer1 || !killPlayer2)
       {
            if (!killPlayer1)
                Destroy(killPlayer2, 3);

            if (!killPlayer2)
                Destroy(killPlayer1, 3);

            Destroy(killDome);
            safetyDome.transform.localScale = new Vector3(14, 14, 14);
            spawnPlayers();
            spawnSafetyDome();
       }
        
    }
}
