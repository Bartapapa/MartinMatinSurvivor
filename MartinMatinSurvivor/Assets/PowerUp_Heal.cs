using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Heal : A_PowerUp
{
    public int Heal = 5;
    public override float GetAffectedValue()
    {
        return Heal;
    }
    protected override void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }
}
