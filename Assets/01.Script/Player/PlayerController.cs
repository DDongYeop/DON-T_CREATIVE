using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageData stageData;

    private PlayerFire _playerFire;
    private Movement _movement;


    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _playerFire = GetComponent<PlayerFire>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _movement.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(KeyCode.Space))
            _playerFire.StartPlayerAttack();
        else if (Input.GetKeyUp(KeyCode.Space))
            _playerFire.StopPlayerAttack();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x)
          , Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), 0);
    }
}
