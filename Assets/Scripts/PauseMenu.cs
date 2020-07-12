using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject PlayButton;
    public TMPro.TMP_Text PauseText;
    public AudioSource bgm;
    public bool GameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (GameEnded)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Have to do: Continue Audio!!!!
        bgm?.UnPause();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //Have to do: Pause Audio!!!!
        bgm?.Pause();
    }

    public void PauseToEndGame(string text)
    {
        GameEnded = true;
        GameIsPaused = true;
        Time.timeScale = 0f;
        PlayButton.SetActive(false);
        PauseMenuUI.SetActive(true);
        PauseText.text = text;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameEnded = false;
        PlayButton.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
