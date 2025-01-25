using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject[] bubblePrefabs; // �ϰ���Ԥ��������
    public Transform[] spawnPoints; // ���ɵ�
    public float minSpawnRate = 1.0f; // ��С���ɼ��
    public float maxSpawnRate = 3.0f; // ������ɼ��
    public float endSpawnRate = 0.5f;
    private float nextSpawnTime;

    void Update()
    {
        // ��ȡ GameManager �еķ���
        int score = GameManager.Instance.score;

        // ���ݷ��������ϰ������ɼ��
        float difficultyFactor = Mathf.Clamp(score / 100f, 0f, 1f); // �Ѷ����ӣ�����Խ�ߣ��Ѷ�Խ�����Ϊ1��
        float newMinRate = Mathf.Lerp(minSpawnRate, endSpawnRate, difficultyFactor); // ��С������ŷ������������
        float newMaxRate = Mathf.Lerp(maxSpawnRate, endSpawnRate, difficultyFactor); // ��������ŷ������������

        if (Time.time >= nextSpawnTime)
        {
            SpawnBubble();

            // �����´�����ʱ��
            nextSpawnTime = Time.time + Random.Range(newMinRate, newMaxRate);
        }
    }

    void SpawnBubble()
    {
        if (bubblePrefabs.Length == 0) return;

        // ���ѡ��һ���ϰ���
        int prefabIndex = Random.Range(0, bubblePrefabs.Length);
        GameObject chosenPrefab = bubblePrefabs[prefabIndex];

        if (chosenPrefab == null)
        {
            Debug.LogWarning("SpawnBubble: ѡ�е�Ԥ����Ϊ�գ��������ɡ�");
            return;
        }

        // ���ѡ��һ�����ɵ�
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // �����ϰ���
        Instantiate(chosenPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
}
