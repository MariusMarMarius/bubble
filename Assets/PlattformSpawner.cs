using UnityEngine;

public class PlattformManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 障碍物预制体数组
    public Transform[] spawnPoints; // 生成点
    public float minSpawnRate = 1.0f; // 最小生成间隔
    public float maxSpawnRate = 3.0f; // 最大生成间隔
    private float nextSpawnTime;

    void Update()
    {
        // 读取 GameManager 中的分数
        int score = GameManager.Instance.score;

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();

            // 设置下次生成时间
            nextSpawnTime = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0) return;

        // 随机选择一个障碍物
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenPrefab = obstaclePrefabs[prefabIndex];

        if (chosenPrefab == null)
        {
            Debug.LogWarning("SpawnObstacle: 选中的预制体为空，跳过生成。");
            return;
        }

        // 随机选择一个生成点
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // 生成障碍物
        Instantiate(chosenPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
}
