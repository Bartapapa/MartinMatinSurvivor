using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupButton : MonoBehaviour
{
    public A_PowerUp AssignedPowerup;
    public Transform characterwhatever;

    public void BuyPowerup()
    {
        ResourceManager.instance.LoseResource(ResourceManager.instance.ResourceThreshold);
        A_PowerUp powerup = Instantiate<A_PowerUp>(AssignedPowerup, characterwhatever.position, Quaternion.identity);
    }
}
