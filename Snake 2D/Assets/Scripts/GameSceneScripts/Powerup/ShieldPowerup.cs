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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player1Controller>())
        {
            SoundManager.Instance.Play(Sounds.POWERUP_EFFECT_START);

            Player1PowerupController playerPowerupController = other.gameObject.GetComponent<Player1PowerupController>();
            playerPowerupController.ActivatePowerup(PowerupType.SHIELD);

            Destroy(this.gameObject);
        }
        else if (other.gameObject.GetComponent<Player2Controller>())
        {
            SoundManager.Instance.Play(Sounds.POWERUP_EFFECT_START);

            Player2PowerupController playerPowerupController = other.gameObject.GetComponent<Player2PowerupController>();
            playerPowerupController.ActivatePowerup(PowerupType.SHIELD);

            Destroy(this.gameObject);
        }
    }
}
