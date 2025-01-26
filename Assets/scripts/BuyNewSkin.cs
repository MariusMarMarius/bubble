using TMPro;
using UnityEngine;

public class BuyNewSkin : MonoBehaviour
{
    public GameObject skin1tobuy;
    public GameObject skin1owned;
    public GameObject skin2tobuy;
    public GameObject skin2owned;
    public GameObject skin3tobuy;
    public GameObject skin3owned;
    public TextMeshProUGUI tipps;
    

    private void Start()
    {
        skin1tobuy.SetActive(true);
        skin2tobuy.SetActive(true);
        skin3tobuy.SetActive(true);
        skin1owned.SetActive(false);
        skin2owned.SetActive(false);
        skin3owned.SetActive(false);

    }
    public void buy1Skin()
    {
        skin1owned.SetActive(true);
        skin1tobuy.SetActive(false);
    }
    public void buy2Skin()
    {
        skin2owned.SetActive(true);
        skin2tobuy.SetActive(false);
    }
    public void buy3Skin()
    {
        skin3owned.SetActive(true);
        skin3tobuy.SetActive(false);
    }
}
