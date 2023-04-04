using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform FollowTarget;

    private void LateUpdate()
    {
        transform.position = FollowTarget.position;
    }
}
