using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int Resource = 0;
    public int ResourceThreshold = 100;

    public GameObject UpgradeUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        UpgradeUI.SetActive(false);
    }

    public void AcquireResource(int quantity)
    {
        Resource += quantity;
        if (Resource >= ResourceThreshold)
        {
            UpgradeUI.SetActive(true);
        }
    }

    public void LoseResource(int quantity)
    {
        Resource -= quantity;
        if (Resource < ResourceThreshold)
        {
            UpgradeUI.SetActive(false);
        }
    }
}
