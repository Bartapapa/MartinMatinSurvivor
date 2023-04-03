using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health parameters")]
    public int MaxHealth = 10;
    public int CurrentHealth = 0;

    [Header("Death")]
    public GameObject drop;
    public int ResourceDrop = 0;

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

    public void Heal(int heal)
    {
        if (!IsDead)
        {
            CurrentHealth += heal;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }

    public void IncreaseHealth(int increase)
    {
        MaxHealth += increase;
        CurrentHealth += increase;
    }

    private void Die()
    {
        IsDead = true;

        if (drop)
        {
            GameObject dropped = Instantiate<GameObject>(drop, transform.position, Quaternion.identity);
            //instantiate drop at transform.position
        }

        if (ResourceDrop > 0)
        {
            ResourceManager.instance.AcquireResource(ResourceDrop);
        }

        Destroy(this.gameObject);
    }
}
