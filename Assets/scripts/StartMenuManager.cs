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
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
