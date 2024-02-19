using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIManager : MonoBehaviour
{
    [Header("In App Texts")]
    public Text coinText;
    public Text coin500Price;
    public Text newBikePrice;
    public Text elitePrice;

    private void Start()
    {
        SetWallet();
    }


    public void BuyCoinsIAP(int num) {
        //Debug.Log("I am being clicked");
        StoreManager.Instance.BuyProduct(num);
        SetWallet();
    }
    private void SetWallet() { 
    
        coinText.text = PlayerPrefs.GetInt("Coins",0).ToString();
    }
}
