using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _snakeBody;

    private float _speed = 5.0f;
    private int _snakeBodySize;

    private Vector2 _snakePosition;
    private MovementDirection _movementDirection;

    private List<Vector2> _snakePositionList;
    private List<Transform> _snakeBodyTransformList;

    private void Start()
    {
        _snakePosition = new Vector2(10f, 10f);
        transform.position = new Vector3(_snakePosition.x, _snakePosition.y, 0f);

        _snakePositionList = new List<Vector2>();
        _snakeBodyTransformList = new List<Transform>();
    }

    private void Update()
    {
        Movement();
        if(Input.GetMouseButtonDown(0))
        {
            _snakeBodySize++;
            CreateSnakeBody();
        }
    }

    private void Movement()
    {
        _snakePositionList.Insert(0, _snakePosition);

        if (Input.GetKeyDown(KeyCode.W) && _movementDirection != MovementDirection.DOWN)
        {
            _rigidBody.velocity = Vector2.up * _speed;
            _movementDirection = MovementDirection.UP;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.D) && _movementDirection != MovementDirection.LEFT)
        {
            _rigidBody.velocity = Vector2.right * _speed;
            _movementDirection = MovementDirection.RIGHT;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.A) && _movementDirection != MovementDirection.RIGHT)
        {
            _rigidBody.velocity = Vector2.left * _speed;
            _movementDirection = MovementDirection.LEFT;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.S) && _movementDirection != MovementDirection.UP)
        {
            _rigidBody.velocity = Vector2.down * _speed;
            _movementDirection = MovementDirection.DOWN;
            HandleSnakeFaceDirection(_movementDirection);
        }

        if (_snakePositionList.Count >= _snakeBodySize + 1)
        {
            _snakePositionList.RemoveAt(_snakePositionList.Count - 1);
        }

        for (int i = 0; i < _snakeBodyTransformList.Count; i++)
        {
            Vector3 snakeBodyPosition = new Vector3(_snakePositionList[i].x, _snakePositionList[i].y, 0);
            _snakeBodyTransformList[i].position = snakeBodyPosition;
        }
    }

    private void HandleSnakeFaceDirection(MovementDirection faceDirection)
    {
        switch (faceDirection)
        {
            case MovementDirection.UP:
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case MovementDirection.DOWN:
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;

            case MovementDirection.LEFT:
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;

            case MovementDirection.RIGHT:
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.eulerAngles = new Vector3(0, 0, -90);
                break;
        }
    }

    private void CreateSnakeBody()
    {
        _snakeBodyTransformList.Add(_snakeBody.transform);
        Instantiate(_snakeBody, _snakeBody.transform);
    }
}

public enum MovementDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}