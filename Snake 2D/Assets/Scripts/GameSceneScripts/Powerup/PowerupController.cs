using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerupObjects = new GameObject[3];

    private float minimumYPos = 0.1f;
    private float maximumYPos = 0.3f;
    private float yPosition;
    private float bounceSpeed = 3;

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
        // Calculate the sine value based on time and bounceSpeed
        float sinValue = Mathf.Sin(Time.time * bounceSpeed);

        // Interpolate between maximum and minimum Y positions
        yPosition = Mathf.Lerp(maximumYPos, minimumYPos, Mathf.Abs(sinValue));

        // Update the power-up's position
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
