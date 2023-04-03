using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [Header("Timer")]
    public float _timeToDestroy = 10f;
    private float _timer = 0f;

    private void Update()
    {
        if (_timer <= _timeToDestroy)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
