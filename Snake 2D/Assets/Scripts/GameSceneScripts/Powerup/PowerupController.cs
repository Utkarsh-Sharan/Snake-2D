using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerupObjects = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            int i = Random.Range(0, _powerupObjects.Length);
            GameObject powerupInstance = Instantiate(_powerupObjects[i]);
            Destroy(powerupInstance, 3.0f);
        } 
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
}
