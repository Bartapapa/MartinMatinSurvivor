using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [Header("Object references")]
    public CharacterController _CC;
    public Weapon _W;
    public Health _H;

    [Header("List")]
    public List<SO_PowerUpHolder> PowerupList = new List<SO_PowerUpHolder>();

    public void AcquirePowerup(A_PowerUp acquired)
    {
        if (acquired.Type == PowerUpType.HealthHeal)
        {
            _H.Heal((int)acquired.GetAffectedValue());
        }
        else
        {
            SO_PowerUpHolder powerUp = ScriptableObject.CreateInstance<SO_PowerUpHolder>();
            powerUp.Set(acquired);
            PowerupList.Add(powerUp);
            CalculatePowerUpBonuses();
        }
    }

    public void RemovePowerup(SO_PowerUpHolder powerUp)
    {
        PowerupList.Remove(powerUp);
        Destroy(powerUp);

        CalculatePowerUpBonuses();
    }

    private void Update()
    {
        foreach (SO_PowerUpHolder powerup in PowerupList)
        {
            if (powerup.TimeLeft >= 0)
            {
                powerup.TimeLeft -= Time.deltaTime;
                if (powerup.TimeLeft <= 0)
                {
                    RemovePowerup(powerup);
                }
            }
            //powerups with a duration of less than 0 are never deleted.
        }
    }

    private void CalculatePowerUpBonuses()
    {
        float CalculatedMoveSpeedFactor = 1f;
        float CalculatedFireSpeedFactor = 1f;
        int CalculatedMaxHealth = 10;
        int CalculatedBulletCount = 1;
        int CalculatedPenetrationCount = 1;

        foreach(SO_PowerUpHolder powerup in PowerupList)
        {
            switch (powerup.Type)
            {
                case PowerUpType.FireSpeed:
                    float FSfactor = powerup.Factor;
                    CalculatedFireSpeedFactor = CalculatedFireSpeedFactor * FSfactor;
                    break;
                case PowerUpType.MoveSpeed:
                    float MSfactor = powerup.Factor;
                    CalculatedMoveSpeedFactor = CalculatedMoveSpeedFactor + (CalculatedMoveSpeedFactor * MSfactor);
                    break;
                case PowerUpType.MaxHealthUp:
                    float MHbonus = powerup.Factor;
                    CalculatedMaxHealth += (int) MHbonus;
                    break;
                case PowerUpType.HealthHeal:
                    break;
                case PowerUpType.BulletPlus:
                    float BCbonus = powerup.Factor;
                    CalculatedBulletCount += (int)BCbonus;
                    break;
                case PowerUpType.PenetrationPlus:
                    float PCbonus = powerup.Factor;
                    CalculatedPenetrationCount += (int)PCbonus;
                    break;
                default:
                    break;
            }
        }

        _CC.MovementFactor = CalculatedMoveSpeedFactor;
        _W.FireSpeedFactor = CalculatedFireSpeedFactor;
        _H.MaxHealth = CalculatedMaxHealth;
        _W.BulletCount = CalculatedBulletCount;
        _W.PenetrationCount = CalculatedPenetrationCount;
    }
}
