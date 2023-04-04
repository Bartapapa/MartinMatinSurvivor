using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_BulletPlus : A_PowerUp
{
    public int BulletUp = 1;
    public override float GetAffectedValue()
    {
        return BulletUp;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
