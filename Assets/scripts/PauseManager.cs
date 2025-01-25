using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;  // ��Ϸ��ͣʱ��ʾ�Ĳ˵���������һ�� UI ��壩
    private bool isPaused = false;  // �����жϵ�ǰ�Ƿ���ͣ

    void Start()
    {
        // ��ʼʱ��Ϸû����ͣ
        pauseMenu.SetActive(false);  // ��ͣ�˵�Ĭ�ϲ��ɼ�
    }

    // �л���ͣ״̬
    public void TogglePause()
    {
        isPaused = !isPaused;  // �л���ͣ��־
        if (isPaused)
        {
            // ��ͣ��Ϸ
            Time.timeScale = 0f;  // ����ʱ��Ϊ 0����ͣ����ʱ����صĲ���
            pauseMenu.SetActive(true);  // ��ʾ��ͣ�˵�
        }
        else
        {
            // �ָ���Ϸ
            Time.timeScale = 1f;  // �ָ�����ʱ������
            pauseMenu.SetActive(false);  // ������ͣ�˵�
        }
    }

    // �˳���Ϸ��������һ����ť���˳���
    public void QuitGame()
    {
        // �ָ�ʱ����������ֹ��ͣ״̬��������
        Time.timeScale = 1f;

        // ���� Start ����
        SceneManager.LoadScene("start menu");  // ȷ������������ʵ��һ��
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;

        // ���� Start ����
        SceneManager.LoadScene("newscene");  // ȷ������������ʵ��һ��
    }
}
