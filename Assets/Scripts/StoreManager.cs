using System;
using System.Diagnostics;
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

public class StoreManager : MonoBehaviour, IStoreListener
{
    [Header("In App Products")]
    public ConsumableItem consumableItem;
    public NonConsumableItem nonConsumableItem;
    public SubscriptionItem subscriptionItem;

    [Header("Inventory Items")]
    public Text coinsText;

    IStoreController storeController;
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

        storeController.InitiatePurchase(consumableItem.id);
    }
    public void NonConsumableButtonPressed()
    {
        storeController.InitiatePurchase(nonConsumableItem.id);

    }
    public void SubscriptionButtonPressed()
    {
        storeController.InitiatePurchase(subscriptionItem.id);

    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        if (product.definition.id == consumableItem.id) {
        

        }
        else if (product.definition.id == nonConsumableItem.id)
        {


        }
        else if (product.definition.id == subscriptionItem.id)
        {


        }
        return PurchaseProcessingResult.Complete;
    }

    private void SetupBuilder() {


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(consumableItem.id, ProductType.Consumable);
        builder.AddProduct(nonConsumableItem.id, ProductType.NonConsumable);
        builder.AddProduct(subscriptionItem.id, ProductType.Subscription);

        UnityPurchasing.Initialize(this, builder);
    
    
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        UnityEngine.Debug.Log("Store controller initialized");
        storeController= controller;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        UnityEngine.Debug.Log("Purchase Failed");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        UnityEngine.Debug.Log("Purchase Failed");
    }

    
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        UnityEngine.Debug.Log("Purchase Failed");
    }

   
}
