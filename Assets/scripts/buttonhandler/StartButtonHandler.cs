using UnityEngine;
using UnityEngine.SceneManagement;  // ������س����������ռ�

public class StartButtonHandler : MonoBehaviour
{
    // ��ť���ʱ���õĺ���
    public void OnStartButtonClicked()
    {
        // ͨ�������������µĳ���
        SceneManager.LoadScene("newscene");
    }
}
