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

    public float FireSpeedFactor = 1f;
    public int BulletCount = 1;
    public int PenetrationCount = 1;
    public float BaseSpread = 5f;

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
                    if (_timeSinceLastShot > CurrentWeapon._timeBetweenTwoShots*FireSpeedFactor)
                    {
                        Shoot();
                    }
                }
                break;
            case SO_Weapon.FireInputMethod.Hold:
                if (_timeSinceLastShot > CurrentWeapon._timeBetweenTwoShots*FireSpeedFactor)
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
        StartCoroutine(ShootAllProjectiles());

        //A_Projectile newProjectile = Instantiate<A_Projectile>(CurrentWeapon._projectile, _spawner.position, _spawner.rotation);
        //newProjectile.SetProjectile(CurrentWeapon, PenetrationCount);

        //_timeSinceLastShot = 0f;
        //Debug.Log("shoot!");
    }

    private IEnumerator ShootAllProjectiles()
    {
        _timeSinceLastShot = 0f;
        int bulletsShot = 0;
        while (bulletsShot < BulletCount)
        {
            Debug.Log(bulletsShot);
            float randomRot = Random.Range(-BaseSpread*BulletCount, BaseSpread*BulletCount);
            A_Projectile newProjectile = Instantiate<A_Projectile>(CurrentWeapon._projectile, _spawner.position, _spawner.rotation);
            newProjectile.SetProjectile(CurrentWeapon, PenetrationCount);
            newProjectile.transform.Rotate(0, randomRot, 0);
            bulletsShot += 1;
            Debug.Log(bulletsShot);

            yield return null;
        }
        yield return null;
    }
}
