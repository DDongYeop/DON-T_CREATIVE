using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    [SerializeField] private float _larpTime = 0.1f;

    private Text _textWarning;
    private float _realTime;

    private void Awake()
    {
        _textWarning = GetComponent<Text>();
    }

    private void Update()
    {
        _realTime += Time.deltaTime;
        TimeScale();
    }

    private IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerpLoop_(Color.clear, Color.red));
            yield return StartCoroutine(ColorLerpLoop_(Color.red, Color.clear));
        }
    }

    private IEnumerator ColorLerpLoop_(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while ( percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / _larpTime;

            _textWarning.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }

    private void TimeScale()
    {
        if (_realTime <= 30)
        {
            _textWarning.color = Color.clear;
        }
        else if (_realTime <= 37)
        {
            StartCoroutine(ColorLerpLoop());
        }
        else
        {
            StopAllCoroutines();
            _textWarning.color = Color.clear;
        }
    }
}
