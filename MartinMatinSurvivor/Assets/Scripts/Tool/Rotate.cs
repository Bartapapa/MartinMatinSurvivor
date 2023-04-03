using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateSpeed = 110f;

    private void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
}
