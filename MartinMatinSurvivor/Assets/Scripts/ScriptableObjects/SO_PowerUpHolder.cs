using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_PowerUpHolder : ScriptableObject
{
    public float Factor;
    public PowerUpType Type;
    public float TimeLeft = 30f;

    public void Set(A_PowerUp powerup)
    {
        Factor = powerup.GetAffectedValue();
        Type = powerup.Type;
        TimeLeft = powerup.PowerupDuration;
    }
}
