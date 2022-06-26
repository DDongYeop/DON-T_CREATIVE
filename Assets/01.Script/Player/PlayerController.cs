using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageData stageData;

    private PlayerFire _playerFire;
    private Movement _movement;
    private Meteor_Boss _meteorBoss;
    private Staellite_Boss _staelliteBoss;
    private Space_Station_Boss _spaceStationBoss;


    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _playerFire = GetComponent<PlayerFire>();
        if (SceneManager.GetActiveScene().buildIndex == 2)
            _meteorBoss = GameObject.Find("Meteor_Boss").GetComponent<Meteor_Boss>();
        if (SceneManager.GetActiveScene().buildIndex == 3)
            _staelliteBoss = GameObject.Find("Satellite_Boss").GetComponent<Staellite_Boss>();
        if (SceneManager.GetActiveScene().buildIndex == 4)
            _spaceStationBoss = GameObject.Find("Space_Station_Boss").GetComponent<Space_Station_Boss>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

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

    public void Die()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            _meteorBoss.MeteorBossPlayer();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            _staelliteBoss.StaelliteBossPlayer();
        else if (SceneManager.GetActiveScene().buildIndex == 4)
            _spaceStationBoss.SpaceStationBossPlayer();
    }
}
