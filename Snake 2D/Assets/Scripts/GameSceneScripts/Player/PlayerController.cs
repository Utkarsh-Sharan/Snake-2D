using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    [SerializeField] protected Transform snakeBody;
    [SerializeField] protected Camera mainCamera;
    [SerializeField] protected GameObject gameOverUIPanel;

    protected int snakeBodySize;
    protected Vector2 snakeMove;
    protected MovementDirection movementDirection;

    protected float screenWidth;
    protected float screenHeight;
    protected float boundaryCheckOffset = 1f;

    protected List<Transform> snakeBodyTransformList;

    protected abstract void Start();

    protected void Update()
    {
        Movement();
        WrapSnakeHead();
    }

    protected void FixedUpdate()
    {
        //adds body parts from back
        for (int i = snakeBodyTransformList.Count - 1; i > 0; i--)
        {
            snakeBodyTransformList[i].position = snakeBodyTransformList[i - 1].position;
        }

        //rigidbody movement
        this.transform.position = new Vector3(
                                         Mathf.Round(this.transform.position.x + snakeMove.x),
                                         Mathf.Round(this.transform.position.y + snakeMove.y),
                                         0f);

        //wrapping snake's body
        WrapSnakeHead();
    }

    protected abstract void Movement();

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
        Vector3 snakeHeadPosition = snakeBodyTransformList[0].position;

        //checking at x-axis
        if (snakeHeadPosition.x > screenWidth)
        {
            snakeHeadPosition.x = -screenWidth;
        }
        else if (snakeHeadPosition.x < -screenWidth)
        {
            snakeHeadPosition.x = screenWidth;
        }

        //checking at y-axis
        if (snakeHeadPosition.y > screenHeight)
        {
            snakeHeadPosition.y = -screenHeight;
        }
        else if (snakeHeadPosition.y < -screenHeight)
        {
            snakeHeadPosition.y = screenHeight;
        }

        snakeBodyTransformList[0].position = snakeHeadPosition;
    }

    protected abstract void OnCollisionEnter2D(Collision2D other);

    protected bool IsWithinBoundaryExclusionZone(Vector3 position)
    {
        // Check if the snake head is within the exclusion zone of the leftmost or rightmost boundary
        return position.x <= -screenWidth + boundaryCheckOffset ||
               position.x >= screenWidth - boundaryCheckOffset;
    }

    public void CreateSnakeBody()
    {
        snakeBodySize++;

        //instantiating and storing the body
        Transform snakeBody = Instantiate(this.snakeBody);

        //setting the body position
        snakeBody.position = snakeBodyTransformList[snakeBodyTransformList.Count - 1].position;

        //adding it to the list
        snakeBodyTransformList.Add(snakeBody);
    }

    public void DestroySnakeBody()
    {
        if (snakeBodyTransformList.Count > 1) // There must be at least one body part to remove
        {
            snakeBodySize--;

            // Getting the last body part
            Transform lastBodyPart = snakeBodyTransformList[snakeBodyTransformList.Count - 1];

            // Removing it from the list
            snakeBodyTransformList.RemoveAt(snakeBodyTransformList.Count - 1);

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