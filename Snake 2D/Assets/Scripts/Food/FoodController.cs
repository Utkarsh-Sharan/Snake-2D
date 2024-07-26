using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodController : MonoBehaviour
{
    [SerializeField] protected BoxCollider2D foodSpawnArea;
    [SerializeField] protected PlayerController playerController;

    // Start is called before the first frame update
    protected void Start()
    {
        RandomizePosition();
    }

    protected void RandomizePosition()
    {
        Bounds bounds = foodSpawnArea.bounds;

        float boundX = Random.Range(bounds.min.x, bounds.max.x);
        float boundY = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(boundX), Mathf.Round(boundY), 0f);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
}
