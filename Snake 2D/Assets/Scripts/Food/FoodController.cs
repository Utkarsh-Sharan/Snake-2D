using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] protected BoxCollider2D foodSpawnArea;
    [SerializeField] protected PlayerController playerController;

    protected float _spawnInterval = 3f;

    protected void RandomizeFoodPosition()
    {
        Bounds bounds = foodSpawnArea.bounds;

        float boundX = Random.Range(bounds.min.x, bounds.max.x);
        float boundY = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(boundX), Mathf.Round(boundY), 0f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) { }
}
