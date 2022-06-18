using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreViewer : MonoBehaviour
{
    private Text _textScore;

    public static int score;

    void Start()
    {
        _textScore = GetComponent<Text>();
        score = 000;
    }

    void Update()
    {
        _textScore.text = "Score : " + score;
    }
}
