using TMPro;
using UnityEngine;

public class BuyNewSkin : MonoBehaviour
{
    GameObject skin1tobuy;
    GameObject skin1owned;
    GameObject skin2tobuy;
    GameObject skin2owned;
    GameObject skin3tobuy;
    GameObject skin3owned;
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
    void buy1Skin()
    {

    }
}
