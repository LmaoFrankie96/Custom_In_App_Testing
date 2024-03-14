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

    [Header("In App Buttons")]
    public Button coinBtn;
    public Button bikeBtn;
    public Button eliteBtn;

    [Header("In App Images")]
    public Image bikeImage;
    public Image eliteImage;
    private void Start()
    {
        UpdateWallet();
    }


    public void BuyIAP(int num)
    {
        //Debug.Log("I am being clicked");
        StoreManager.Instance.BuyProduct(num);
        UpdateWallet();
    }
    private void UpdateWallet()
    {

        coinText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        if (PlayerPrefs.GetInt("Bike1", 0) == 1)
        {
            bikeImage.gameObject.SetActive(true);
            bikeBtn.interactable = false;
            newBikePrice.text = "Purchased";
        }
        if (PlayerPrefs.GetInt("Coins", 0) >= 15000)
        {
            coinBtn.interactable = false;
            coin500Price.text = "Purchased";
        }
        if (PlayerPrefs.GetInt("Elite", 0) == 1)
        {
            eliteImage.gameObject.SetActive(true);
            eliteBtn.interactable = false;
            elitePrice.text = "Purchased";

        }
    }

}
