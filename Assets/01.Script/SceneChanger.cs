using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int SceneNumber;

    [SerializeField] private int SceneNumber1;
    [SerializeField] private int SceneNumber2;
    [SerializeField] private int SceneNumber3;
    [SerializeField] private int SceneNumber4;
    [SerializeField] private int SceneNumber5;

    public void Exit()
    {
        Application.Quit();
        Debug.Log("GAME EXIT");
    }

    public void PlayerScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    public void PlayerScene1()
    {
        SceneManager.LoadScene(SceneNumber1);
    }

    public void PlayerScene2()
    {
        SceneManager.LoadScene(SceneNumber2);
    }

    public void PlayerScene3()
    {
        SceneManager.LoadScene(SceneNumber3);
    }

    public void PlayerScene4()
    {
        SceneManager.LoadScene(SceneNumber4);
    }

    public void PlayerScene5()
    {
        SceneManager.LoadScene(SceneNumber5);
    }
}
