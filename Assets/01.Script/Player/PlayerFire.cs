using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject _playerbullet;
    [SerializeField] private Transform _playerFirePos;
    [SerializeField] private float _playerFireSpeed = 0.1f;

    public void StartPlayerAttack()
    {
        StartCoroutine("CoPlayerAttack");
    }

    public void StopPlayerAttack()
    {
        StopCoroutine("CoPlayerAttack");
    }

    private IEnumerator CoPlayerAttack()
    {
        while (true)
        {
            GameObject bullet = Instantiate(_playerbullet);
            bullet.transform.position = _playerFirePos.position;
            
            yield return new WaitForSeconds(_playerFireSpeed);
        }
    }

}
