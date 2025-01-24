using UnityEngine;

public class PlattformManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // �ϰ���Ԥ��������
    public Transform[] spawnPoints; // ���ɵ�
    public float minSpawnRate = 1.0f; // ��С���ɼ��
    public float maxSpawnRate = 3.0f; // ������ɼ��
    private float nextSpawnTime;

    void Update()
    {
        // ��ȡ GameManager �еķ���
        int score = GameManager.Instance.score;

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();

            // �����´�����ʱ��
            nextSpawnTime = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0) return;

        // ���ѡ��һ���ϰ���
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenPrefab = obstaclePrefabs[prefabIndex];

        if (chosenPrefab == null)
        {
            Debug.LogWarning("SpawnObstacle: ѡ�е�Ԥ����Ϊ�գ��������ɡ�");
            return;
        }

        // ���ѡ��һ�����ɵ�
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // �����ϰ���
        Instantiate(chosenPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
}
