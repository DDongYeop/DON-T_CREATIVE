using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField] private PlayerHP _playerHP;
    private Slider _sliderHP;

    private void Start()
    {
        _sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {

        _sliderHP.value = _playerHP.CurrentHP / _playerHP.MaxHP;
    }
}
