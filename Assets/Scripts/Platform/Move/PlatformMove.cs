using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField]
    private InputController input;
    [SerializeField]
    private PlatformMoveData pmData;

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        pmData.InitializeData();
        input.onClick.AddListener(ChangeDirection);
    }

    private void OnDisable()
    {
        input.onClick.RemoveListener(ChangeDirection);
    }

    private void Move()
    {
        // Movement direction.
        Vector3 direction;
        if (pmData.moveDirectionLeft)
        {
            // Move left.
            direction = Vector3.back;
            transform.Translate(direction * pmData.speed * Time.fixedDeltaTime);
        }
        else
        {
            // Move right.
            direction = Vector3.left;
            transform.Translate(direction * pmData.speed * Time.fixedDeltaTime);
        }
    }

    private void ChangeDirection()
    {
        pmData.moveDirectionLeft = !pmData.moveDirectionLeft;
    }
}
