using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int Resource = 0;
    public int ResourceThreshold = 100;


    public XPBar xpBar;



    public GameObject UpgradeUI;
    public GameObject UpgradeUIImage;

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
        UpgradeUIImage.SetActive(false);


        xpBar.slider.maxValue = ResourceThreshold;

        xpBar.SetXp(Resource);

    }

    public void AcquireResource(int quantity)
    {
        Resource += quantity;

        if (xpBar != null)
        {
            xpBar.SetXp(Resource);
        }

        if (Resource >= ResourceThreshold)
        {
            UpgradeUI.SetActive(true);
            UpgradeUIImage.SetActive(true);

        }
    }

    public void LoseResource(int quantity)
    {
        Resource -= quantity;
        if (Resource < ResourceThreshold)
        {
            UpgradeUI.SetActive(false);
            UpgradeUIImage.SetActive(false);

        }
    }
}
