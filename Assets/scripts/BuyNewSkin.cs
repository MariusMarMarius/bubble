using TMPro;
using UnityEngine;

public class BuyNewSkin : MonoBehaviour
{
    public GameObject skin1tobuy;
    public GameObject skin1owned;
    public GameObject skin2tobuy;
    public GameObject skin2owned;
    public GameObject skin3tobuy; // skin3 Ŀǰ������
    public GameObject skin3owned;

    public TMP_Text coinText; // ��ʾ��ǰ�������
    private int coins;

    private void Start()
    {
        // ��ȡ�洢�Ľ������
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinDisplay();

        // ��ȡƤ������״̬
        bool isSkin1Owned = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        bool isSkin2Owned = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;

        // ���� UI ״̬
        skin1tobuy.SetActive(!isSkin1Owned);
        skin1owned.SetActive(isSkin1Owned);

        skin2tobuy.SetActive(!isSkin2Owned);
        skin2owned.SetActive(isSkin2Owned);

        // skin3 Ŀǰ������
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
            Debug.Log("�ɹ�����Ƥ��1");
        }
        else
        {
            Debug.Log("��Ҳ��㣬�޷�����Ƥ��1");
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
            Debug.Log("�ɹ�����Ƥ��2");
        }
        else
        {
            Debug.Log("��Ҳ��㣬�޷�����Ƥ��2");
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
