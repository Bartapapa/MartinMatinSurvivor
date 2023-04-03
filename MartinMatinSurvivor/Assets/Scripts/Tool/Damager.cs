using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [Header("Parameters")]
    public bool DestroyOnHit = true;
    public int Damage = 1;
    public int PenetrationCount = 1;

    private int currentPenetrationCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        Health defender = other.GetComponent<Health>();
        if (defender)
        {
            defender.Hurt(Damage);
            currentPenetrationCount += 1;

            if (currentPenetrationCount >= PenetrationCount)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
