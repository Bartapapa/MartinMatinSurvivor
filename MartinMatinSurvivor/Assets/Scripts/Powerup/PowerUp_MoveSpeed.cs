using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_MoveSpeed : A_PowerUp
{
    [Header("Powerup Parameters")]
    public float MoveSpeedFactor = 1.5f;

    public override float GetAffectedValue()
    {
        return MoveSpeedFactor;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
