using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 障碍物预制体数组
    public Transform[] spawnPoints; // 生成点
    public float minSpawnRate = 1.0f; // 最小生成间隔
    public float maxSpawnRate = 3.0f; // 最大生成间隔
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();

            // **游戏越久，障碍物生成越快**
            float difficultyFactor = Mathf.Clamp(Time.time / 60f, 0f, 1f); // 逐渐增加难度（最大 1）
            float newMinRate = Mathf.Lerp(1.0f, 0.5f, difficultyFactor); // 最小间隔从 1.0 降到 0.5
            float newMaxRate = Mathf.Lerp(3.0f, 1.0f, difficultyFactor); // 最大间隔从 3.0 降到 1.0

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



