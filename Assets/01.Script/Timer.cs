using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timer;
    private float _time;

    private float _msec;
    private float _sec;
    private float _min;

    private void Start()
    {
        StartCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        while (true)
        {
            _time += Time.deltaTime;
            _msec = (int)((_time - (int)_time) * 100);
            _sec = (int)(_time % 60);
            _min = (int)(_time / 60 % 60);

            _timer.text = string.Format("{0:00} : {1:00} : {2:00}", _min, _sec, _msec);

            yield return null;
        }
    }
}
