using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{
    private static bool _plus5PowerupStatus;
    public static bool Plus5PowerupStatus { get { return _plus5PowerupStatus; } }

    private static bool _shieldPowerupStatus;
    public static bool ShieldPowerupStatus { get { return _shieldPowerupStatus; } }

    private static bool _speedBoostPowerupStatus;
    public static bool SpeedBoostPowerupStatus { get { return _speedBoostPowerupStatus; } }

    public void ActivatePowerup(PowerupType powerupType)
    {
        switch (powerupType)
        {
            case PowerupType.PLUS_5:
                _plus5PowerupStatus = true;
                StartCoroutine(Plus5PowerupCooldownRoutine());
                break;

            case PowerupType.SHIELD:
                _shieldPowerupStatus = true;
                StartCoroutine(ShieldPowerupCooldownRoutine());
                break;

            case PowerupType.SPEED_BOOST:
                _speedBoostPowerupStatus = true;
                StartCoroutine(SpeedBoostPowerupCooldownRoutine());
                break;
        }
    }

    private IEnumerator Plus5PowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(5f);

        _plus5PowerupStatus = false;
    }

    private IEnumerator ShieldPowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(5f);

        _shieldPowerupStatus = false;
    }

    private IEnumerator SpeedBoostPowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(5f);

        _speedBoostPowerupStatus = false;
    }
}

public enum PowerupType
{
    PLUS_5,
    SHIELD,
    SPEED_BOOST
}