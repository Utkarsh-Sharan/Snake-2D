using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : PowerupController
{
    //variables for animation
    private float _minimumYPos = 0.1f;
    private float _maximumYPos = 0.3f;
    private float _initialYPosition;
    private float _bounceSpeed = 3;

    void Start()
    {
        _initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Calculate the sine value based on time and bounceSpeed
        float sinValue = Mathf.Sin(Time.time * _bounceSpeed);

        // Interpolate between maximum and minimum Y positions
        float yPosition = Mathf.Lerp(_maximumYPos, _minimumYPos, Mathf.Abs(sinValue));

        // Update the power-up's position
        transform.position = new Vector3(transform.position.x, _initialYPosition + yPosition, transform.position.z);
    }
}
