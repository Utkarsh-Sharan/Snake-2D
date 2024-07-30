using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{
    private static bool _plus5PowerupStatus;
    public static bool Plus5PowerupStatus { get { return _plus5PowerupStatus; } }

    private static bool _shieldPowerupStatus;
    public static bool ShieldPowerupStatus { get { return _shieldPowerupStatus; } set { _shieldPowerupStatus = value; } }

    private static bool _speedBoostPowerupStatus;
    public static bool SpeedBoostPowerupStatus { get { return _speedBoostPowerupStatus; } set { _speedBoostPowerupStatus = value; } }

    public static IEnumerator Plus5PowerupCooldownRoutine()
    {
        _plus5PowerupStatus = true;
        yield return new WaitForSeconds(5f);
        _plus5PowerupStatus = false;
    }
}
