using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Material[] materialList;
    public Color[] colorList;
    public Image winScreenBackground;
    public Renderer rend;
    public Renderer rend2;
    public Renderer prefabRend;
    public Renderer prefabRedn2;
    public gameManager manager;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public Canvas MainMenuCanvas;
    public Text controlsText;
    public Text seriesText;
    public SpawnManager spawn;
    GameObject p1;
    GameObject p2;


    private void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");

        rend = p1.GetComponent<Renderer>();
        rend2 = p2.GetComponent<Renderer>();

        controlsText.gameObject.SetActive(false);
        seriesText.gameObject.SetActive(false);
    }

    private void Update()
    {
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
    }

    public void SinglePlayer()
    {
        spawn.singlePlayer = true;
        spawn.multiplayer = false;
    }

    public void Multiplayer()
    {
        spawn.singlePlayer = false;
        spawn.multiplayer = true;
    }
    public void PlayGame()
    {
        GameObject titleText = MainMenuCanvas.transform.GetChild(0).Find("Title Text").gameObject;
        titleText.SetActive(false);

        GameObject playbutton = MainMenuCanvas.transform.GetChild(0).Find("PlayGame Button").gameObject;
        playbutton.SetActive(false);

        GameObject optionsButton = MainMenuCanvas.transform.GetChild(0).Find("Options Button").gameObject;
        optionsButton.SetActive(false);
        
        GameObject controlsButton = MainMenuCanvas.transform.GetChild(0).Find("Controls Button").gameObject;
        controlsButton.SetActive(false);

        GameObject exitButton = MainMenuCanvas.transform.GetChild(0).Find("Quit Game Button").gameObject;
        exitButton.SetActive(false);

        camera2.Priority = 3;
        StartCoroutine(manager.countdownToStart());
    }

    public void Options()
    {
        GameObject playbutton = MainMenuCanvas.transform.GetChild(0).Find("PlayGame Button").gameObject;
        playbutton.SetActive(false);

        GameObject optionsButton = MainMenuCanvas.transform.GetChild(0).Find("Options Button").gameObject;
        optionsButton.SetActive(false);

        GameObject controlsButton = MainMenuCanvas.transform.GetChild(0).Find("Controls Button").gameObject;
        controlsButton.SetActive(false);

        GameObject exitButton = MainMenuCanvas.transform.GetChild(0).Find("Quit Game Button").gameObject;
        exitButton.SetActive(false);

        GameObject backButton = MainMenuCanvas.transform.GetChild(0).Find("Back To Main Menu From Options").gameObject;
        backButton.SetActive(true);

        GameObject seriesButtonOne = MainMenuCanvas.transform.GetChild(0).Find("2-3 Series Button").gameObject;
        seriesButtonOne.SetActive(true);

        GameObject seriesButtonTwo = MainMenuCanvas.transform.GetChild(0).Find("4-7 Series Button").gameObject;
        seriesButtonTwo.SetActive(true);

        GameObject redButton = MainMenuCanvas.transform.GetChild(0).Find("Red").gameObject;
        redButton.SetActive(true);

        GameObject blackButton = MainMenuCanvas.transform.GetChild(0).Find("Black").gameObject;
        blackButton.SetActive(true);

        GameObject blueButton = MainMenuCanvas.transform.GetChild(0).Find("Blue").gameObject;
        blueButton.SetActive(true);

        GameObject greenButton = MainMenuCanvas.transform.GetChild(0).Find("Green").gameObject;
        greenButton.SetActive(true);

        GameObject orangeButton = MainMenuCanvas.transform.GetChild(0).Find("Orange").gameObject;
        orangeButton.SetActive(true);

        GameObject purpleButton = MainMenuCanvas.transform.GetChild(0).Find("Purple").gameObject;
        purpleButton.SetActive(true);

        GameObject yellowButton = MainMenuCanvas.transform.GetChild(0).Find("Yellow").gameObject;
        yellowButton.SetActive(true);

        GameObject blackButton2 = MainMenuCanvas.transform.GetChild(0).Find("Black 2").gameObject;
        blackButton2.SetActive(true);

        GameObject redButton2 = MainMenuCanvas.transform.GetChild(0).Find("Red 2").gameObject;
        redButton2.SetActive(true);

        GameObject blueButton2 = MainMenuCanvas.transform.GetChild(0).Find("Blue 2").gameObject;
        blueButton2.SetActive(true);

        GameObject greenButton2 = MainMenuCanvas.transform.GetChild(0).Find("Green 2").gameObject;
        greenButton2.SetActive(true);

        GameObject orangeButton2 = MainMenuCanvas.transform.GetChild(0).Find("Orange 2").gameObject;
        orangeButton2.SetActive(true);

        GameObject purpleButton2 = MainMenuCanvas.transform.GetChild(0).Find("Purple 2").gameObject;
        purpleButton2.SetActive(true);

        GameObject yellowButton2 = MainMenuCanvas.transform.GetChild(0).Find("Yellow 2").gameObject;
        yellowButton2.SetActive(true);

        GameObject singlePlayerButton = MainMenuCanvas.transform.GetChild(0).Find("SinglePlayer").gameObject;
        singlePlayerButton.SetActive(true);

        GameObject multiplayerButtom = MainMenuCanvas.transform.GetChild(0).Find("Multiplayer").gameObject;
        multiplayerButtom.SetActive(true);

        seriesText.gameObject.SetActive(true);
    }

    public void playerOneRed()
    {
        rend.sharedMaterial = materialList[1];
        prefabRend.material = materialList[1];
        winScreenBackground.color = colorList[1];
    }

    public void playerOneBlack()
    {
        rend.sharedMaterial = materialList[0];
        prefabRend.material = materialList[0];
        winScreenBackground.color = colorList[0];
    }

    public void playerOneBlue()
    {
        rend.material = materialList[2];
        prefabRend.material = materialList[2];
        winScreenBackground.color = colorList[2];
    }

    public void playerOneGreen()
    {
        rend.material = materialList[3];
        prefabRend.material = materialList[3];
        winScreenBackground.color = colorList[3];
    }

    public void playerOneOrange()
    {
        rend.material = materialList[4];
        prefabRend.material = materialList[4];
        winScreenBackground.color = colorList[4];
    }

    public void playerOnePurple()
    {
        rend.material = materialList[5];
        prefabRend.material = materialList[5];
        winScreenBackground.color = colorList[5];
    }

    public void playerOneYellow()
    {
        rend.material = materialList[6];
        prefabRend.material = materialList[6];
        winScreenBackground.color = colorList[6];
    }

    public void playerTwoRed()
    {
        rend2.material = materialList[1];
        prefabRedn2.material = materialList[1];
        winScreenBackground.color = colorList[1];
    }

    public void playerTwoBlack()
    {
        rend2.material = materialList[0];
        prefabRedn2.material = materialList[0];
        winScreenBackground.color = colorList[0];
    }

    public void playerTwoBlue()
    {
        rend2.material = materialList[2];
        prefabRedn2.material = materialList[2];
        winScreenBackground.color = colorList[2];
    }

    public void playerTwoGreen()
    {
        rend2.material = materialList[3];
        prefabRedn2.material = materialList[3];
        winScreenBackground.color = colorList[3];
    }

    public void playerTwoOrange()
    {
        rend2.material = materialList[4];
        prefabRedn2.material = materialList[4];
        winScreenBackground.color = colorList[4];
    }

    public void playerTwoPurple()
    {
        rend2.material = materialList[5];
        prefabRedn2.material = materialList[5];
        winScreenBackground.color = colorList[5];
    }

    public void playerTwoYellow()
    {
        rend2.material = materialList[6];
        prefabRedn2.material = materialList[6];
        winScreenBackground.color = colorList[6];
    }

    public void Controls()
    {
        GameObject playbutton = MainMenuCanvas.transform.GetChild(0).Find("PlayGame Button").gameObject;
        playbutton.SetActive(false);

        GameObject optionsButton = MainMenuCanvas.transform.GetChild(0).Find("Options Button").gameObject;
        optionsButton.SetActive(false);

        GameObject controlsButton = MainMenuCanvas.transform.GetChild(0).Find("Controls Button").gameObject;
        controlsButton.SetActive(false);

        GameObject exitButton = MainMenuCanvas.transform.GetChild(0).Find("Quit Game Button").gameObject;
        exitButton.SetActive(false);

        controlsText.gameObject.SetActive(true);
        GameObject backButton = MainMenuCanvas.transform.GetChild(0).Find("Back To Main Menu").gameObject;
        backButton.SetActive(true);

    }

    public void BackToMainMenuFromControls()
    {
        controlsText.gameObject.SetActive(false);
        GameObject backButton = MainMenuCanvas.transform.GetChild(0).Find("Back To Main Menu").gameObject;
        backButton.SetActive(false);

        GameObject playbutton = MainMenuCanvas.transform.GetChild(0).Find("PlayGame Button").gameObject;
        playbutton.SetActive(true);

        GameObject optionsButton = MainMenuCanvas.transform.GetChild(0).Find("Options Button").gameObject;
        optionsButton.SetActive(true);

        GameObject controlsButton = MainMenuCanvas.transform.GetChild(0).Find("Controls Button").gameObject;
        controlsButton.SetActive(true);

        GameObject exitButton = MainMenuCanvas.transform.GetChild(0).Find("Quit Game Button").gameObject;
        exitButton.SetActive(true);
    }

    public void BackToMainMenuFromOptions()
    {
        seriesText.gameObject.SetActive(false);

        GameObject singlePlayerButton = MainMenuCanvas.transform.GetChild(0).Find("SinglePlayer").gameObject;
        singlePlayerButton.SetActive(false);

        GameObject multiplayerButtom = MainMenuCanvas.transform.GetChild(0).Find("Multiplayer").gameObject;
        multiplayerButtom.SetActive(false);

        GameObject backButton = MainMenuCanvas.transform.GetChild(0).Find("Back To Main Menu From Options").gameObject;
        backButton.SetActive(false);

        GameObject seriesButtonOne = MainMenuCanvas.transform.GetChild(0).Find("2-3 Series Button").gameObject;
        seriesButtonOne.SetActive(false);

        GameObject seriesButtonTwo = MainMenuCanvas.transform.GetChild(0).Find("4-7 Series Button").gameObject;
        seriesButtonTwo.SetActive(false);

        GameObject redButton = MainMenuCanvas.transform.GetChild(0).Find("Red").gameObject;
        redButton.SetActive(false);

        GameObject blackButton = MainMenuCanvas.transform.GetChild(0).Find("Black").gameObject;
        blackButton.SetActive(false);

        GameObject blueButton = MainMenuCanvas.transform.GetChild(0).Find("Blue").gameObject;
        blueButton.SetActive(false);

        GameObject greenButton = MainMenuCanvas.transform.GetChild(0).Find("Green").gameObject;
        greenButton.SetActive(false);

        GameObject orangeButton = MainMenuCanvas.transform.GetChild(0).Find("Orange").gameObject;
        orangeButton.SetActive(false);

        GameObject purpleButton = MainMenuCanvas.transform.GetChild(0).Find("Purple").gameObject;
        purpleButton.SetActive(false);

        GameObject yellowButton = MainMenuCanvas.transform.GetChild(0).Find("Yellow").gameObject;
        yellowButton.SetActive(false);

        GameObject blackButton2 = MainMenuCanvas.transform.GetChild(0).Find("Black 2").gameObject;
        blackButton2.SetActive(false);

        GameObject redButton2 = MainMenuCanvas.transform.GetChild(0).Find("Red 2").gameObject;
        redButton2.SetActive(false);

        GameObject blueButton2 = MainMenuCanvas.transform.GetChild(0).Find("Blue 2").gameObject;
        blueButton2.SetActive(false);

        GameObject greenButton2 = MainMenuCanvas.transform.GetChild(0).Find("Green 2").gameObject;
        greenButton2.SetActive(false);

        GameObject orangeButton2 = MainMenuCanvas.transform.GetChild(0).Find("Orange 2").gameObject;
        orangeButton2.SetActive(false);

        GameObject purpleButton2 = MainMenuCanvas.transform.GetChild(0).Find("Purple 2").gameObject;
        purpleButton2.SetActive(false);

        GameObject yellowButton2 = MainMenuCanvas.transform.GetChild(0).Find("Yellow 2").gameObject;
        yellowButton2.SetActive(false);

        GameObject playbutton = MainMenuCanvas.transform.GetChild(0).Find("PlayGame Button").gameObject;
        playbutton.SetActive(true);

        GameObject optionsButton = MainMenuCanvas.transform.GetChild(0).Find("Options Button").gameObject;
        optionsButton.SetActive(true);

        GameObject controlsButton = MainMenuCanvas.transform.GetChild(0).Find("Controls Button").gameObject;
        controlsButton.SetActive(true);

        GameObject exitButton = MainMenuCanvas.transform.GetChild(0).Find("Quit Game Button").gameObject;
        exitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TwoSeries()
    {
        manager.gamesToWin = 2;
    }

    public void FourSeries()
    {
        manager.gamesToWin = 4;
    }
}
