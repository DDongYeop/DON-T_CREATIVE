using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseESC : MonoBehaviour
{
    [SerializeField] private int sceneNumber = 0;

    private void Update()
    {
        InputESC();
    }

    private void InputESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(sceneNumber);
    }
}
