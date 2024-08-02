using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerController
{
    protected override void Start()
    {
        transform.position = new Vector3(5f, 0f, 0f);       //snake's initial position

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
        if (Input.GetKeyDown(KeyCode.UpArrow) && movementDirection != MovementDirection.DOWN)
        {
            snakeMove = Vector2.up;
            movementDirection = MovementDirection.UP;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && movementDirection != MovementDirection.LEFT)
        {
            snakeMove = Vector2.right;
            movementDirection = MovementDirection.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && movementDirection != MovementDirection.RIGHT)
        {
            snakeMove = Vector2.left;
            movementDirection = MovementDirection.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && movementDirection != MovementDirection.UP)
        {
            snakeMove = Vector2.down;
            movementDirection = MovementDirection.DOWN;
        }

        HandleSnakeFaceDirection(movementDirection);
    }
}
