using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        
        // �л�����Ϸ����
        SceneManager.LoadScene("newscene");
    }

    public void BackHome()
    {
        
        // �л�����Ϸ����
        SceneManager.LoadScene("start menu");
    }
}
