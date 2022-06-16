using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
}
