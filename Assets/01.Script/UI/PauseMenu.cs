using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private int _thisSceneNumber;

    public GameObject pauseMenuUI;
    bool isToggled;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (isToggled == true)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }
    void Pause()
    {
        isToggled = !isToggled;
        pauseMenuUI.SetActive(isToggled);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Pause();
    }

    public void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_thisSceneNumber);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Exit");
    }
}
