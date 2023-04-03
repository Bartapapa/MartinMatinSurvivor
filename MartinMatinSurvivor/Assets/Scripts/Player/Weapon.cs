using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Current weapon")]
    public SO_Weapon CurrentWeapon;

    [Header("Projectile Spawner")]
    public Transform _spawner;

    private float _timeSinceLastShot = 0f;
    private bool _shootKeyUpSinceLastShot = true;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    public void SetInput(PlayerCharacterInputs inputs)
    {
        // Shooting input
        if (inputs.ShootDown)
        {
            RequestShoot();
            _shootKeyUpSinceLastShot = false;
        }
        else
        {
            _shootKeyUpSinceLastShot = true;
        }
    }

    public void RequestShoot()
    {
        switch (CurrentWeapon._fireInputMethod)
        {
            case SO_Weapon.FireInputMethod.Single:
                if (_shootKeyUpSinceLastShot)
                {
                    if (_timeSinceLastShot > CurrentWeapon._timeBetweenTwoShots)
                    {
                        Shoot();
                    }
                }
                break;
            case SO_Weapon.FireInputMethod.Hold:
                if (_timeSinceLastShot > CurrentWeapon._timeBetweenTwoShots)
                {
                    Shoot();
                }
                break;
            default:
                break;
        }
    }

    private void Shoot()
    {
        A_Projectile newProjectile = Instantiate<A_Projectile>(CurrentWeapon._projectile, _spawner.position, _spawner.rotation);
        newProjectile.SetProjectile(CurrentWeapon);

        _timeSinceLastShot = 0f;
        Debug.Log("shoot!");
    }
}
