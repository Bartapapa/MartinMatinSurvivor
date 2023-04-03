using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_PenetrationPlus : A_PowerUp
{
    public int PenetrationUp = 1;
    public override float GetAffectedValue()
    {
        return PenetrationUp;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
