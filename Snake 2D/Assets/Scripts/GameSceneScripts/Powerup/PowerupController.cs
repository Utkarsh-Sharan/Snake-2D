using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerupObjects = new GameObject[3];
    [SerializeField] private BoxCollider2D _powerupSpawnArea;

    private void Start()
    {
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            int i = Random.Range(0, _powerupObjects.Length);
            Vector3 randomSpawnPosition = RandomizePowerupPosition();

            GameObject powerupInstance = Instantiate(_powerupObjects[i], randomSpawnPosition, Quaternion.identity);   //direct destruction of game objects is not allowed in unity
            Destroy(powerupInstance, 3.0f);                                                                           //so, destroying its instance
        } 
    }

    private Vector3 RandomizePowerupPosition()
    {
        Bounds bounds = _powerupSpawnArea.bounds;

        float boundX = Random.Range(bounds.min.x, bounds.max.x);
        float boundY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(Mathf.Round(boundX), Mathf.Round(boundY), 0f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) { }
}
