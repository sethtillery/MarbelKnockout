using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class mainMenu : MonoBehaviour
{
    public gameManager manager;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public Canvas MainMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayGame()
    {
        GameObject playbutton = MainMenuCanvas.transform.Find("PlayGame Button").gameObject;
        playbutton.SetActive(false);
        camera2.Priority = 3;
        StartCoroutine(manager.countdownToStart());
    }
}
