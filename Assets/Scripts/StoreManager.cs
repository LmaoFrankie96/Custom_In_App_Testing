using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
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

public class StoreManager : IStoreListener
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
        SetupBuilder();
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
    private void SetupBuilder() {


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(consumableItem.id, ProductType.Consumable);
        builder.AddProduct(nonConsumableItem.id, ProductType.NonConsumable);
        builder.AddProduct(subscriptionItem.id, ProductType.Subscription);

        UnityPurchasing.Initialize(this, builder);
    
    
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        throw new NotImplementedException();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        throw new NotImplementedException();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        throw new NotImplementedException();
    }
}
