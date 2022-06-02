using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        movement.MoveTo(new Vector3(x, y, 0));
    }
}
