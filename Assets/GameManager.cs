using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ����ģʽ�����������ű�����
    public int score = 0;   // ��ǰ����
    public float difficulty = 1.0f; // ��Ϸ�Ѷȣ����Ը��ݷ����ȵ�����

    public float scoreIncreaseRate = 1.0f;  // ÿ�����ӵķ���

    private float timeSinceLastScoreIncrease = 0f;  // �����ϴ����ӷ�����ʱ��

    void Awake()
    {
        // ��� GameManager ʵ��Ϊ�գ�����Ϊ��ǰ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ȷ��ֻ��һ�� GameManager ����
        }

        // ���� GameManager �ڳ����л�ʱ��������
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // ����ʱ�����ӷ���
        IncreaseScoreOverTime();

        // ���ݷ�����������������������Ϸ�Ѷ�
        UpdateDifficulty();
    }

    void IncreaseScoreOverTime()
    {
        timeSinceLastScoreIncrease += Time.deltaTime;  // ����ʱ��

        if (timeSinceLastScoreIncrease >= 1f)  // ÿ������һ�η���
        {
            score += 1;  // ���ӷ���
            timeSinceLastScoreIncrease = 0f;  // ���ü�ʱ
        }
    }

    void UpdateDifficulty()
    {
        if (score < 50)
        {
            difficulty = 1.0f;
        }
        else if (score < 100)
        {
            difficulty = 1.5f;
        }
        else
        {
            difficulty = 2.0f;
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}
