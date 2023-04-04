using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_FireSpeed : A_PowerUp
{
    [Header("Powerup Parameters")]
    public float FireSpeedFactor = .1f;

    public override float GetAffectedValue()
    {
        return FireSpeedFactor;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
