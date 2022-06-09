using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageData stageData;

    Movement movement;


    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.MoveTo(new Vector3(x, y, 0));
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x)
          , Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), 0);
    }
}
