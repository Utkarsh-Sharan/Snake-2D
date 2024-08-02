using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1PowerupController : MonoBehaviour
{
    private static bool _plus5PowerupStatus;
    public static bool Plus5PowerupStatus { get { return _plus5PowerupStatus; } }

    private static bool _shieldPowerupStatus;
    public static bool ShieldPowerupStatus { get { return _shieldPowerupStatus; } }

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
        }
    }

    private IEnumerator Plus5PowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(5f);

        SoundManager.Instance.Play(Sounds.POWERUP_EFFECT_END);
        _plus5PowerupStatus = false;
    }

    private IEnumerator ShieldPowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(5f);

        SoundManager.Instance.Play(Sounds.POWERUP_EFFECT_END);
        _shieldPowerupStatus = false;
    }
}
