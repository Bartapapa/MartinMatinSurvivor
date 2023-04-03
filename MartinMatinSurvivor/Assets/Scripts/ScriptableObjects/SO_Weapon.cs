using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MartinMatinSurvivor/Weapons/Weapon")]
public class SO_Weapon : ScriptableObject
{
    public enum FireInputMethod
    {
        Single,
        Hold,
    }

    [Header("Object references")]
    public A_Projectile _projectile;
    public GameObject _weaponModel;

    [Header("Parameters")]
    public FireInputMethod _fireInputMethod = FireInputMethod.Single;
    public float _timeBetweenTwoShots = .2f;
    public float _projectileSpeed = 10f;
    public int _projectileDamage = 1;

    public GameObject WeaponModel => _weaponModel;
}
