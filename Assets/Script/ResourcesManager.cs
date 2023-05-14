using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [Header("Resources")]
    [Space(8)]

    public int maxWood;
    public int wood;

    public int maxStone;
    public int stone;

    public int maxPremiumCurrency;
    public int premiumC;

    public int maxStandardCurrency;
    public  int standardC;

    private static ResourcesManager instance;
    public static ResourcesManager Instance => instance;


    public bool debugBool = false;
    private void Awake()
    {
        ResourcesManager.instance = this;
    }

    private void Update()
    {

        if (debugBool)
        {
            UpdateUICurrentResource();
            debugBool = false;
        }
        
    }


    public bool AddWood(int amount)
    {
        if ((wood + amount) <= maxWood)
        {
            wood += amount;
            UIManager.Instance.UpdateWoodUI(wood, maxWood);
            return true;
        }
        return false;

    }

    public bool AddStone(int amount)
    {
        if ((stone + amount) <= maxStone)
        {
            stone += amount;
            UIManager.Instance.UpdateRockUI(stone, maxStone);
            return true;
        }
        return false;
        

    }

    public bool AddPremium(int amount)
    {
        if ((premiumC + amount) <= maxPremiumCurrency)
        {
            premiumC += amount;
            UIManager.Instance.UpdatePremiumCUI(premiumC, maxPremiumCurrency);
            return true;
        }
        return false;

      
    }

    public bool AddStandard(int amount)
    {
        if ((standardC + amount) <= maxStandardCurrency)
        {
            standardC += amount;
            UIManager.Instance.UpdateStandardCUI(standardC, maxPremiumCurrency);
            return true;
        }
        return false;

        
    }

    void UpdateUICurrentResource()
    {
        Debug.Log("wood " + wood);
        Debug.Log("stone " + stone);
        Debug.Log("PremiumCurrency " + premiumC);
        Debug.Log("StandardCurrency " + standardC);
    }
}
