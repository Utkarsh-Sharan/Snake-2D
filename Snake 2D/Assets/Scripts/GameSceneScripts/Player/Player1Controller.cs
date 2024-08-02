using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController
{
    protected override void Start()
    {
        if(GameManager.Instance.GameType == GameType.SINGLE_PLAYER)
        {
            transform.position = new Vector3(0f, 0f, 0f);       //snake's initial position
        }
        else
        {
            transform.position = new Vector3(-5f, 0f, 0f);
        }

        snakeBodyTransformList = new List<Transform>();    //initializing transform list
        snakeBodyTransformList.Add(this.transform);        //adding snake's head to the list

        float cameraHeight = mainCamera.orthographicSize * 2;  //as camera's orthographic size is half the height
        float cameraWidth = cameraHeight * mainCamera.aspect;  //as camera's aspect ratio = width/height

        screenWidth = cameraWidth / 2;
        screenHeight = cameraHeight / 2;
    }

    protected override void Movement()
    {
        //handling inputs in update
        if (Input.GetKeyDown(KeyCode.W) && movementDirection != MovementDirection.DOWN)
        {
            snakeMove = Vector2.up;
            movementDirection = MovementDirection.UP;
        }
        else if (Input.GetKeyDown(KeyCode.D) && movementDirection != MovementDirection.LEFT)
        {
            snakeMove = Vector2.right;
            movementDirection = MovementDirection.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.A) && movementDirection != MovementDirection.RIGHT)
        {
            snakeMove = Vector2.left;
            movementDirection = MovementDirection.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.S) && movementDirection != MovementDirection.UP)
        {
            snakeMove = Vector2.down;
            movementDirection = MovementDirection.DOWN;
        }

        HandleSnakeFaceDirection(movementDirection);
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (IsWithinBoundaryExclusionZone(transform.position) || Player1PowerupController.ShieldPowerupStatus == true)
        {
            return; // Skip collision check
        }
        else if (other.gameObject.GetComponent<GreenSnakeBodyPart>())
        {
            SoundManager.Instance.PlayMusic(Sounds.PLAYER_DEATH);
            GameManager.Instance.GameOverHandler(gameOverUIPanel);
        }
    }
}
