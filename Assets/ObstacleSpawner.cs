using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 障碍物预制体数组
    public Transform[] spawnPoints; // 生成点
    public float minSpawnRate = 1.0f; // 最小生成间隔
    public float maxSpawnRate = 3.0f; // 最大生成间隔
    public float endSpawnRate = 0.5f;
    private float nextSpawnTime;

    void Update()
    {
        // 读取 GameManager 中的分数
        int score = GameManager.Instance.score;

        // 根据分数调整障碍物生成间隔
        float difficultyFactor = Mathf.Clamp(score / 100f, 0f, 1f); // 难度因子：分数越高，难度越大（最大为1）
        float newMinRate = Mathf.Lerp(minSpawnRate, endSpawnRate, difficultyFactor); // 最小间隔随着分数增大而减少
        float newMaxRate = Mathf.Lerp(maxSpawnRate, endSpawnRate, difficultyFactor); // 最大间隔随着分数增大而减少

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();

            // 设置下次生成时间
            nextSpawnTime = Time.time + Random.Range(newMinRate, newMaxRate);
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
