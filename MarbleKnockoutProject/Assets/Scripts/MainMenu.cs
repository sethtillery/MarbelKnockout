using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstGameScene;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(firstGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void OptionsMenuOpen()
    {

    }

    public void OptionsMenuClose()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
