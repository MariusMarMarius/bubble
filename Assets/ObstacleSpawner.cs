using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // �ϰ���Ԥ��������
    public Transform[] spawnPoints; // ���ɵ�
    public float minSpawnRate = 1.0f; // ��С���ɼ��
    public float maxSpawnRate = 3.0f; // ������ɼ��
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();

            // **��ϷԽ�ã��ϰ�������Խ��**
            float difficultyFactor = Mathf.Clamp(Time.time / 60f, 0f, 1f); // �������Ѷȣ���� 1��
            float newMinRate = Mathf.Lerp(1.0f, 0.5f, difficultyFactor); // ��С����� 1.0 ���� 0.5
            float newMaxRate = Mathf.Lerp(3.0f, 1.0f, difficultyFactor); // ������� 3.0 ���� 1.0

            nextSpawnTime = Time.time + Random.Range(newMinRate, newMaxRate);
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



