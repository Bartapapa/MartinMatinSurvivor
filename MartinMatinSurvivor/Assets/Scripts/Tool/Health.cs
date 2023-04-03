using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health parameters")]
    public int MaxHealth = 10;
    public int CurrentHealth = 0;

    public bool IsDead = false;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Hurt(int damage)
    {
        if (!IsDead)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        IsDead = true;

        Destroy(this.gameObject);
    }
}
