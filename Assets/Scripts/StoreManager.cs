using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class StoreManager : MonoBehaviour, IStoreListener
{


    public List<string> InAppProducts;

    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
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
        InitializePurchasing();
    }
    
    public void BuyProduct(int num)
    {

        BuyProductID(InAppProducts[num]);
    }
    private void BuyProductID(string MproductID)
    {
        if (IsInitialized() == false) Debug.Log("Store controller is NOT initialized and is being called from buyproductID function");
        if (IsInitialized())
        {
            Debug.Log("Store controller is initialized and is being called from buyproductID function");
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
                PurchaseSuccess(InAppProducts[i]);
                flag = PurchaseProcessingResult.Complete;
                break;
            }
        }

        return flag;
    }
    public void PurchaseSuccess(string id)
    {

        switch (id)
        {

            case "coins500":
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + 500);
                break;
            case "newbike":
                PlayerPrefs.SetInt("Bike1", 1);
                break;
            case "elite":
                PlayerPrefs.SetInt("Elite", 1);
                break;
        }
    }
    public void InitializePurchasing()
    {

        if (IsInitialized())
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        for (int i = 0; i < InAppProducts.Count; i++)
        {

            if (i == 0) builder.AddProduct(InAppProducts[i], ProductType.Consumable);
            if (i == 1) builder.AddProduct(InAppProducts[i], ProductType.NonConsumable);
            if (i == 2) builder.AddProduct(InAppProducts[i], ProductType.Subscription);
        }
        UnityPurchasing.Initialize(this, builder);
        Debug.Log("Store controller is initialized and builder also initialized in InitializePurchasing() function");
    }
    private bool IsInitialized()
    {
        
        return storeController != null && extensionProvider != null;
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Store controller initialized");
        storeController = controller;
        extensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Purchase Failed");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Purchase Failed");
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Failed");
    }


}
