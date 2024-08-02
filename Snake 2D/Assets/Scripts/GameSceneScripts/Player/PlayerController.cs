using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Transform _snakeBody;
    [SerializeField] protected Camera _camera;
    [SerializeField] protected GameObject _gameOverUIPanel;

    protected int _snakeBodySize;
    protected Vector2 _snakeMove;
    protected MovementDirection _movementDirection;

    protected float _screenWidth;
    protected float _screenHeight;
    protected float _boundaryCheckOffset = 1f;

    protected List<Transform> _snakeBodyTransformList;

    protected void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);       //snake's initial position

        _snakeBodyTransformList = new List<Transform>();    //initializing transform list
        _snakeBodyTransformList.Add(this.transform);        //adding snake's head to the list

        float cameraHeight = _camera.orthographicSize * 2;  //as camera's orthographic size is half the height
        float cameraWidth = cameraHeight * _camera.aspect;  //as camera's aspect ratio = width/height

        _screenWidth = cameraWidth / 2;
        _screenHeight = cameraHeight / 2;
    }

    protected void Update()
    {
        Movement();
        WrapSnakeHead();
    }

    protected void FixedUpdate()
    {
        //adds body parts from back
        for (int i = _snakeBodyTransformList.Count - 1; i > 0; i--)
        {
            _snakeBodyTransformList[i].position = _snakeBodyTransformList[i - 1].position;
        }

        //rigidbody movement
        this.transform.position = new Vector3(
                                         Mathf.Round(this.transform.position.x + _snakeMove.x),
                                         Mathf.Round(this.transform.position.y + _snakeMove.y),
                                         0f);

        //wrapping snake's body
        WrapSnakeHead();
    }

    protected void Movement()
    {
        //handling inputs in update
        if (Input.GetKeyDown(KeyCode.W) && _movementDirection != MovementDirection.DOWN)
        {
            _snakeMove = Vector2.up;
            _movementDirection = MovementDirection.UP;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _movementDirection != MovementDirection.LEFT)
        {
            _snakeMove = Vector2.right;
            _movementDirection = MovementDirection.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _movementDirection != MovementDirection.RIGHT)
        {
            _snakeMove = Vector2.left;
            _movementDirection = MovementDirection.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _movementDirection != MovementDirection.UP)
        {
            _snakeMove = Vector2.down;
            _movementDirection = MovementDirection.DOWN;
        }

        HandleSnakeFaceDirection(_movementDirection);
    }

    protected void HandleSnakeFaceDirection(MovementDirection faceDirection)
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

    protected void WrapSnakeHead()
    {
        Vector3 snakeHeadPosition = _snakeBodyTransformList[0].position;

        //checking at x-axis
        if (snakeHeadPosition.x > _screenWidth)
        {
            snakeHeadPosition.x = -_screenWidth;
        }
        else if (snakeHeadPosition.x < -_screenWidth)
        {
            snakeHeadPosition.x = _screenWidth;
        }

        //checking at y-axis
        if (snakeHeadPosition.y > _screenHeight)
        {
            snakeHeadPosition.y = -_screenHeight;
        }
        else if (snakeHeadPosition.y < -_screenHeight)
        {
            snakeHeadPosition.y = _screenHeight;
        }

        _snakeBodyTransformList[0].position = snakeHeadPosition;
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (IsWithinBoundaryExclusionZone(transform.position) || PlayerPowerupController.ShieldPowerupStatus == true)
        {
            return; // Skip collision check
        }
        else if (other.gameObject.GetComponent<SnakeBodyPart>())
        {
            SoundManager.Instance.PlayMusic(Sounds.PLAYER_DEATH);
            GameManager.Instance.GameOverHandler(_gameOverUIPanel);
        }
    }

    protected bool IsWithinBoundaryExclusionZone(Vector3 position)
    {
        // Check if the snake head is within the exclusion zone of the leftmost or rightmost boundary
        return position.x <= -_screenWidth + _boundaryCheckOffset ||
               position.x >= _screenWidth - _boundaryCheckOffset;
    }

    public void CreateSnakeBody()
    {
        _snakeBodySize++;

        //instantiating and storing the body
        Transform snakeBody = Instantiate(this._snakeBody);

        //setting the body position
        snakeBody.position = _snakeBodyTransformList[_snakeBodyTransformList.Count - 1].position;

        //adding it to the list
        _snakeBodyTransformList.Add(snakeBody);
    }

    public void DestroySnakeBody()
    {
        if (_snakeBodyTransformList.Count > 1) // There must be at least one body part to remove
        {
            _snakeBodySize--;

            // Getting the last body part
            Transform lastBodyPart = _snakeBodyTransformList[_snakeBodyTransformList.Count - 1];

            // Removing it from the list
            _snakeBodyTransformList.RemoveAt(_snakeBodyTransformList.Count - 1);

            // Destroying that body part
            Destroy(lastBodyPart.gameObject);
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