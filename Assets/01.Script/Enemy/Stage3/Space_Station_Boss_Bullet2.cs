using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Station_Boss_Bullet2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float _damage = 1;
    [SerializeField] private int _score = 100;

    
    private void Start()
    {
        //생성으로부터 5초 후 삭제
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamge(_damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Playerbullet"))
        {
            PlayerScoreViewer.score += _score;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
