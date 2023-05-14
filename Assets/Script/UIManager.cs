using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    [Header("References")]

    [Space(8)]
    private static UIManager instance;
    public static UIManager Instance => instance;


    //References for our containers
    public StandardUIReferences _woodUI;
    public StandardUIReferences _stoneUI;
    public StandardUIReferences _standardCUI;
    public StandardUIReferences _premiumCUI;
    






    private void Awake()
    {
        UIManager.instance = this;

    }

    private void Start()
    {
        UpdateAll();

    }

    public void UpdateWoodUI(int currentAmount, int maxAmount)
    {
        _woodUI.maxUI.text = maxAmount.ToString();
        _woodUI.currentUI.text = currentAmount.ToString();
        _woodUI.slider.value = ((float)currentAmount / (float)maxAmount);
    }

    public void UpdateRockUI(int currentAmount, int maxAmount)
    {
        _stoneUI.maxUI.text = maxAmount.ToString();
        _stoneUI.currentUI.text = currentAmount.ToString();
        _stoneUI.slider.value = ((float)currentAmount / (float)maxAmount);
    }

    public void UpdatePremiumCUI(int currentAmount, int maxAmount)
    {
        _premiumCUI.maxUI.text = maxAmount.ToString();
        _premiumCUI.currentUI.text = currentAmount.ToString();
        _premiumCUI.slider.value = ((float)currentAmount / (float)maxAmount);
    }

    public void UpdateStandardCUI(int currentAmount, int maxAmount)
    {
        _standardCUI.maxUI.text = maxAmount.ToString();
        _standardCUI.currentUI.text = currentAmount.ToString();
        _standardCUI.slider.value = ((float)currentAmount / (float)maxAmount);
    }

    void UpdateAll()
    {
        UpdateRockUI(ResourcesManager.Instance.stone, ResourcesManager.Instance.maxStone);
        UpdateWoodUI(ResourcesManager.Instance.wood, ResourcesManager.Instance.maxStone);
        UpdateStandardCUI(ResourcesManager.Instance.standardC, ResourcesManager.Instance.maxStandardCurrency);
        UpdatePremiumCUI(ResourcesManager.Instance.premiumC, ResourcesManager.Instance.maxPremiumCurrency);
    }



    //Main Class for setting up the containers

    [Serializable]
    public class StandardUIReferences
    {
        public Slider slider;
        public TextMeshProUGUI maxUI;
        public TextMeshProUGUI currentUI;
    }
}
