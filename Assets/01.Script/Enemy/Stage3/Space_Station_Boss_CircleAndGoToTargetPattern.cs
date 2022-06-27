using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Station_Boss_CircleAndGoToTargetPattern : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _bullet;



    public void shot()
    {
        //Target�������� �߻�� ������Ʈ ����
        var bl = new List<Transform>();

        for (int i = 0; i < 360; i += 13)
        {
            //�Ѿ� ����
            var temp = Instantiate(_bullet);

            //2���� ����
            Destroy(temp, 5f);

            //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
            //temp.transform.position = Vector2.zero;
            
            Vector2 positionsBullet = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            //?���Ŀ� Target���� ���ư� ������Ʈ ����
            bl.Add(temp.transform);

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        //�Ѿ��� Target �������� �̵���Ų��.
        StartCoroutine(BulletToTarget(bl));
    }

    IEnumerator BulletToTarget(List<Transform> bl)
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < bl.Count; i++)
        {
            //���� �Ѿ��� ��ġ���� �÷����� ��ġ�� ���Ͱ��� �y���Ͽ� ������ ����
            var target_dir = _player.transform.position - bl[i].position;

            //x,y�� ���� �����Ͽ� Z���� ������ ������. -> ~�� ������ ����
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target �������� �̵�
            bl[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //������ ����
        bl.Clear();
    }
}
