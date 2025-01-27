using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    
    public void StartGame()
    {
        // **�����Ѷȵ� PlayerPrefs**
        //PlayerPrefs.SetInt("SelectedDifficulty", difficulty);
        //PlayerPrefs.Save();
        
        // �л�����Ϸ����
        SceneManager.LoadScene("newscene");
        PlayerPrefs.SetInt("Coins",0);
    }
    public void GoShop()
    {
        SceneManager.LoadScene("shop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // �����������
        PlayerPrefs.SetInt("Coins", 100); // �����趨��ʼ���
        PlayerPrefs.SetInt("Skin1Owned", 0);
        PlayerPrefs.SetInt("Skin2Owned", 0);
        PlayerPrefs.Save(); // ȷ������д��
    }

}
