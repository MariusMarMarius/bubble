using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class coinsMangaer : MonoBehaviour
{
    public TextMeshProUGUI coinsNumber;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.GetInt("Coins");
        showCoins();
    }

    void showCoins()
    {
        coinsNumber.text = "" + PlayerPrefs.GetInt("Coins");
    }
}
