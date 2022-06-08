using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("디버그 나왔당");
    }

    public void PlayerScene()
    {
        SceneManager.LoadScene(0);
    }
}
