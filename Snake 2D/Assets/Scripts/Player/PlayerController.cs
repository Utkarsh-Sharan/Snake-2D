using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Transform _snakeFace;

    private float _speed = 2.0f;
    private MovementDirection _movementDirection;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W) && _movementDirection != MovementDirection.DOWN)
        {
            _rigidBody.velocity = Vector2.up * _speed;
            _movementDirection = MovementDirection.UP;
            _snakeFace.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.D) && _movementDirection != MovementDirection.LEFT)
        {
            _rigidBody.velocity = Vector2.right * _speed;
            _movementDirection = MovementDirection.RIGHT;
            _snakeFace.Rotate(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) && _movementDirection != MovementDirection.RIGHT)
        {
            _rigidBody.velocity = Vector2.left * _speed;
            _movementDirection = MovementDirection.LEFT;
            _snakeFace.Rotate(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.S) && _movementDirection != MovementDirection.UP)
        {
            _rigidBody.velocity = Vector2.down * _speed;
            _movementDirection = MovementDirection.DOWN;
            _snakeFace.Rotate(0, 0, -90);
        }
    }
}

public enum MovementDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}