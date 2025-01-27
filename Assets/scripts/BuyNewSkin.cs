using TMPro;
using UnityEngine;

public class BuyNewSkin : MonoBehaviour
{
    public GameObject skin1tobuy;
    public GameObject skin1owned;
    public GameObject skin2tobuy;
    public GameObject skin2owned;
    public GameObject skin3tobuy; // skin3 目前不出售
    public GameObject skin3owned;

    public TMP_Text coinText; // 显示当前金币数量
    private int coins;

    private void Start()
    {
        // 读取存储的金币数量
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinDisplay();

        // 读取皮肤解锁状态
        bool isSkin1Owned = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        bool isSkin2Owned = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;

        // 设置 UI 状态
        skin1tobuy.SetActive(!isSkin1Owned);
        skin1owned.SetActive(isSkin1Owned);

        skin2tobuy.SetActive(!isSkin2Owned);
        skin2owned.SetActive(isSkin2Owned);

        // skin3 目前不出售
        skin3tobuy.SetActive(false);
        skin3owned.SetActive(false);
    }

    public void BuySkin1()
    {
        int price = 20;
        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Skin1Owned", 1);
            PlayerPrefs.Save();

            skin1owned.SetActive(true);
            skin1tobuy.SetActive(false);
            UpdateCoinDisplay();
            Debug.Log("成功购买皮肤1");
        }
        else
        {
            Debug.Log("金币不足，无法购买皮肤1");
        }
    }

    public void BuySkin2()
    {
        int price = 50;
        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Skin2Owned", 1);
            PlayerPrefs.Save();

            skin2owned.SetActive(true);
            skin2tobuy.SetActive(false);
            UpdateCoinDisplay();
            Debug.Log("成功购买皮肤2");
        }
        else
        {
            Debug.Log("金币不足，无法购买皮肤2");
        }
    }

    private void UpdateCoinDisplay()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}
