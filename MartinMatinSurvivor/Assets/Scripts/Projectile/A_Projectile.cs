using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class A_Projectile : MonoBehaviour
{
    [Header("Damager")]
    public Damager Damager;

    [Header("Parameters")]
    public float _projectileSpeed = 10f;
    public int _projectileDamage = 1;

    private void Start()
    {
        if (!Damager)
        {
            Damager = GetComponent<Damager>();
            if (!Damager)
            {
                Debug.Log("No damager found.");
            }
        }
    }

    private void Update()
    {
        DisplaceProjectile();
    }
    protected virtual void DisplaceProjectile()
    {
        transform.position += transform.forward * _projectileSpeed * Time.deltaTime;
    }

    public void SetProjectile(SO_Weapon weaponBase)
    {
        _projectileSpeed = weaponBase._projectileSpeed;
        Damager.Damage = _projectileDamage;
    }
}
