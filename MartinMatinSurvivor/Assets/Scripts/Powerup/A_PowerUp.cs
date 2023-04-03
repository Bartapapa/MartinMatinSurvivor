using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    FireSpeed,
    MoveSpeed,
    MaxHealthUp,
    HealthHeal,
    BulletPlus,
    PenetrationPlus,
}

public abstract class A_PowerUp : MonoBehaviour
{
    [Header("Type")]
    public PowerUpType Type = PowerUpType.FireSpeed;

    [Header("Duration")]
    public float PowerupDuration = 10f;
    protected virtual void AcquirePowerUp(PowerUpHandler handler)
    {
        Destroy(this.gameObject);
    }

    public virtual float GetAffectedValue()
    {
        return 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        PowerUpHandler handler = other.GetComponent<PowerUpHandler>();
        if (handler)
        {
            handler.AcquirePowerup(this);
            AcquirePowerUp(handler);
        }
    }
}
