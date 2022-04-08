
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    public gameManager manager;

    //bool variable to check if pause menu is on or off
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
        pauseMenu.gameObject.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && manager.gamePlaying)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        manager.musicList[1].Pause();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        manager.musicList[1].UnPause();
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //loads main menu
    public void BackToMainMenu()
    {
        manager.musicList[8].Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //quits the game
    public void QuitGame()
    {
        //Closes the application
        Application.Quit();
    }
}
