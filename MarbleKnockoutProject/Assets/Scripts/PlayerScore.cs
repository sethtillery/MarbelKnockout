using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text player1;
    public Text player2;
    public gameManager manager;
    public PlayerController playerOneController;
    public PlayerController1 playerTwoController;
    public SpawnManager spawn;

    // Start is called before the first frame update
    void Start()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        spawn = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gamePlaying)
        {
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
            player1.text = "Player 1: " + spawn.playerOneScore.ToString();
            player2.text = "Player 2: " + spawn.playerTwoScore.ToString();

        }
        else
        {
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
        }
    }
}
