using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [Header("Parameters")]
    public bool DestroyOnHit = true;
    public int Damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Health defender = other.GetComponent<Health>();
        if (defender)
        {
            defender.Hurt(Damage);

            if (DestroyOnHit)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
