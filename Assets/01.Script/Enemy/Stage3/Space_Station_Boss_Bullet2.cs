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
        //�������κ��� 5�� �� ����
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        //�ι�° �Ķ���Ϳ� Space.World�� �������ν� Rotation�� ���� ���� ������ ������
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
