using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class ConsumableItem {

    public string id;
    public string name;
    public string description;
    public float price;
}
[Serializable]
public class NonConsumableItem
{

    public string id;
    public string name;
    public string description;
    public float price;
}

[Serializable]
public class SubscriptionItem
{

    public string id;
    public string name;
    public string description;
    public float price;
    public int timeDuration;
}

public class StoreManager : MonoBehaviour
{
    [Header("In App Products")]
    public ConsumableItem consumableItem;
    public NonConsumableItem nonConsumableItem;
    public SubscriptionItem subscriptionItem;

    [Header("Inventory Items")]
    public Text coinsText;

    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {

        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void ConsumableButtonPressed() { 
    
        
    }
    public void NonConsumableButtonPressed()
    {


    }
}
