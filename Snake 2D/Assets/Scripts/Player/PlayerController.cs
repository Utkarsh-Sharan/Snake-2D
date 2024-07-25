using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _snakeBody;

    private int _snakeBodySize;
    private float _snakeSpeed = 10f;

    private Vector2 _snakeMove;
    private MovementDirection _movementDirection;

    private List<Transform> _snakeBodyTransformList;

    private void Start()
    {
        transform.position = new Vector3(10f, 10f, 0f);

        _snakeBodyTransformList = new List<Transform>();
        _snakeBodyTransformList.Add(this.transform);
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
        if (Input.GetKeyDown(KeyCode.W) && _movementDirection != MovementDirection.DOWN)
        {
            _snakeMove = Vector2.up;
            _movementDirection = MovementDirection.UP;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.D) && _movementDirection != MovementDirection.LEFT)
        {
            _snakeMove = Vector2.right;
            _movementDirection = MovementDirection.RIGHT;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.A) && _movementDirection != MovementDirection.RIGHT)
        {
            _snakeMove = Vector2.left;
            _movementDirection = MovementDirection.LEFT;
            HandleSnakeFaceDirection(_movementDirection);
        }
        else if (Input.GetKeyDown(KeyCode.S) && _movementDirection != MovementDirection.UP)
        {
            _snakeMove = Vector2.down;
            _movementDirection = MovementDirection.DOWN;
            HandleSnakeFaceDirection(_movementDirection);
        }
    }

    private void FixedUpdate()
    {
        for (int i = _snakeBodyTransformList.Count - 1; i > 0; i--)
        {
            _snakeBodyTransformList[i].position = _snakeBodyTransformList[i - 1].position;
        }

        this.transform.position = new Vector3(
                                         Mathf.Round(this.transform.position.x + _snakeMove.x),
                                         Mathf.Round(this.transform.position.y + _snakeMove.y),
                                         0f);
    }

    private void HandleSnakeFaceDirection(MovementDirection faceDirection)
    {
        switch (faceDirection)
        {
            case MovementDirection.UP:
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
        Transform snakeBody = Instantiate(this._snakeBody);
        snakeBody.position = _snakeBodyTransformList[_snakeBodyTransformList.Count - 1].position;
        _snakeBodyTransformList.Add(snakeBody);
    }
}

public enum MovementDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}