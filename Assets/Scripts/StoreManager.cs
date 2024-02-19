using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;




public class StoreManager : MonoBehaviour, IStoreListener
{
    [Header("In App Products")]
    
    public List<string> InAppProducts;

    IStoreController storeController;
    public static StoreManager _instance;
    public static StoreManager Instance
    {

        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StoreManager>();
                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

    }
    private void Start()
    {
        //SetUI();
        SetupBuilder();
    }
    public void BuyProduct(int num)
    {

        BuyProductID(InAppProducts[num]);
    }
    private void BuyProductID(string MproductID)
    {

        if (IsInitialized())
        {

            Product product = storeController.products.WithID(MproductID);

            if (product != null && product.availableToPurchase)
            {

                storeController.InitiatePurchase(product);
                Debug.Log($"Product with product ID: {product.definition.id} is being initiated for purchase");
            }
            else
            {

                Debug.Log($"Product with product ID: {product.definition.id} has FAILED to initiate for purchase");
            }
        }
    }
    
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        PurchaseProcessingResult flag = PurchaseProcessingResult.Pending;
        var product = purchaseEvent.purchasedProduct;
        for (int i = 0; i < InAppProducts.Count; i++)
        {

            if (product.definition.id == InAppProducts[i])
            {

                Debug.Log($"Product with product ID: {InAppProducts[i]} has been successfully purchased");
                flag = PurchaseProcessingResult.Complete;
                break;
            }
        }

        return flag;
    }

    private void SetupBuilder()
    {

        if (IsInitialized())
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            /*builder.AddProduct(consumableItem.id, ProductType.Consumable);
            builder.AddProduct(nonConsumableItem.id, ProductType.NonConsumable);
            builder.AddProduct(subscriptionItem.id, ProductType.Subscription);*/

            UnityPurchasing.Initialize(this, builder);
        }

    }
    private bool IsInitialized()
    {

        return storeController != null;
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        UnityEngine.Debug.Log("Store controller initialized");
        storeController = controller;
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
