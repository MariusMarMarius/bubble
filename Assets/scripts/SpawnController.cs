using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints; // 生成点

    [Header("BubbleSachen")]
    public GameObject bubblePrefab;
    public float minSpawnRate = 1.0f; // 最小生成间隔
    public float maxSpawnRate = 3.0f; // 最大生成间隔
    public float endSpawnRate = 0.5f;
    private float nextSpawnTime;


    [Header("PlatformSachen")]
    public GameObject[] obstaclePrefabs; // 障碍物预制体数组
    //public float PminSpawnRate = 1.0f; // 最小生成间隔
    //public float PmaxSpawnRate = 3.0f; // 最大生成间隔
    //private float PnextSpawnTime;


    [Header("Coin")]
    public GameObject coinPrefab;



    private int score;

    void Update()
    {

        // 根据分数调整障碍物生成间隔
        float difficultyFactor = Mathf.Clamp(score / 100f, 0f, 1f); // 难度因子：分数越高，难度越大（最大为1）
        float newMinRate = Mathf.Lerp(minSpawnRate, endSpawnRate, difficultyFactor); // 最小间隔随着分数增大而减少
        float newMaxRate = Mathf.Lerp(maxSpawnRate, endSpawnRate, difficultyFactor); // 最大间隔随着分数增大而减少

        if (Time.time >= nextSpawnTime)
        {
            int r = Random.Range(0, 100);

            if (r <= 50)
            {
                SpawnBubble();
            } 
            else
            {
                //SpawnPlatform();
            }

            nextSpawnTime = Time.time + Random.Range(newMinRate, newMaxRate);
        }




        /*
        if (Time.time >= PnextSpawnTime)
        {
            SpawnPlatform();

            // 设置下次生成时间
            PnextSpawnTime = Time.time + Random.Range(PminSpawnRate, PmaxSpawnRate);
        }
        */
    }

    void SpawnBubble()
    {
        // 随机选择一个生成点
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // 生成障碍物
        GameObject newBubble = Instantiate(bubblePrefab, chosenSpawnPoint.position, Quaternion.identity);
        
        newBubble.GetComponent<Bubble>().Setup(GameplayColor.GREEN, 1);
    }

    void SpawnPlatform()
    {
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenPrefab = obstaclePrefabs[prefabIndex];

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        GameObject newPlatform = Instantiate(chosenPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
}
