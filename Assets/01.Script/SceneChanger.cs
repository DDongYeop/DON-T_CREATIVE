using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int SceneNumber;

    public void Exit()
    {
        Application.Quit();
        Debug.Log("GAME EXIT");
    }

    public void PlayerScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
