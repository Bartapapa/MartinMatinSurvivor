using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Target")]
    public Transform Target;

    [Header("Parameters")]
    public float MoveSpeed = 5f;

    public void InitializeEnemy(Transform target, float Movespeed)
    {
        Target = target;
        MoveSpeed = Movespeed;
    }

    private void Update()
    {
        if (Target)
        {
            transform.LookAt(Target);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
