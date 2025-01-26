using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectFrameController : MonoBehaviour
{
    public RectTransform selectFrame;  // ѡ���� RectTransform
    public Vector2[] positions;        // �洢����Ƥ���Ĺ̶�λ��
    private int currentIndex = 0;      // ��ǰѡ�е�����

    public bool[] isSkinAvailable;     // Ƥ������״̬����

    void Start()
    {
        // ��ʼ��ʱ��ѡ���̶�����һ��λ��
        if (positions.Length > 0)
        {
            currentIndex = 0;
            UpdatePosition();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1); // �����ƶ�
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1); // �����ƶ�
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // ���س���ѡ��
        {
            SelectSkin();
        }
    }

    void Move(int direction)
    {
        int newIndex = currentIndex + direction;

        // ȷ�����������鷶Χ��
        if (newIndex >= 0 && newIndex < positions.Length)
        {
            currentIndex = newIndex;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // ��ѡ����ƶ�����ǰ����λ��
        selectFrame.anchoredPosition = positions[currentIndex];
    }

    void SelectSkin()
    {
        if (isSkinAvailable.Length > currentIndex && isSkinAvailable[currentIndex])
        {
            Debug.Log("Ƥ���ѽ����������³���");
            PlayerPrefs.SetInt("SelectedSkin", currentIndex); // �洢ѡ���Ƥ������
            SceneManager.LoadScene("NewScene"); // �л����³���
        }
        else
        {
            Debug.Log("Ƥ��δ����");
        }
    }
}

