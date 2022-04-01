using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public gameManager manager;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public Canvas MainMenuCanvas;
    public Text controlsText;

    private void Start()
    {
        controlsText.gameObject.SetActive(false);
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

    public void BackToMainMenu()
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
