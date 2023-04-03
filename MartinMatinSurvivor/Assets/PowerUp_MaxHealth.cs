using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_MaxHealth : A_PowerUp
{
    public int MaxHealthUp = 5;

    public override float GetAffectedValue()
    {
        return MaxHealthUp;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
