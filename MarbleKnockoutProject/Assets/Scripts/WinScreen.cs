using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Image background;
    public Text playerWin;
    public Canvas winScreenCanvas;
    public gameManager manager;
    public SpawnManager spawn;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerWin.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        GameObject mainMenuButton = winScreenCanvas.transform.GetChild(0).Find("Back To Main Menu").gameObject;
        GameObject ExitButton = winScreenCanvas.transform.GetChild(0).Find("Exit Game Button").gameObject;
        mainMenuButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    private void Update()
    {
        if(manager.showWinScreen)
        {
            Debug.Log("spawn screen");
            playerWin.gameObject.SetActive(true);
            background.gameObject.SetActive(true);

            GameObject mainMenuButton = winScreenCanvas.transform.GetChild(0).Find("Back To Main Menu").gameObject;
            GameObject ExitButton = winScreenCanvas.transform.GetChild(0).Find("Exit Game Button").gameObject;

            mainMenuButton.SetActive(true);
            ExitButton.SetActive(true);

            if (spawn.playerOneGameScore == manager.gamesToWin)
                playerWin.text = "Player One Wins";

            if (spawn.playerTwoGameScore == manager.gamesToWin)
                playerWin.text = "Player Two Wins";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
