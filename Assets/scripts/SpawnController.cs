using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints; // ���ɵ�

    [Header("BubbleSachen")]
    public GameObject bubblePrefab;
    public float minSpawnRate = 1.0f; // ��С���ɼ��
    public float maxSpawnRate = 3.0f; // ������ɼ��
    public float endSpawnRate = 0.5f;
    private float nextSpawnTime;


    [Header("PlatformSachen")]
    public GameObject[] obstaclePrefabs; // �ϰ���Ԥ��������
    //public float PminSpawnRate = 1.0f; // ��С���ɼ��
    //public float PmaxSpawnRate = 3.0f; // ������ɼ��
    //private float PnextSpawnTime;


    [Header("Coin")]
    public GameObject coinPrefab;



    private int score;

    void Update()
    {

        // ���ݷ��������ϰ������ɼ��
        float difficultyFactor = Mathf.Clamp(score / 100f, 0f, 1f); // �Ѷ����ӣ�����Խ�ߣ��Ѷ�Խ�����Ϊ1��
        float newMinRate = Mathf.Lerp(minSpawnRate, endSpawnRate, difficultyFactor); // ��С������ŷ������������
        float newMaxRate = Mathf.Lerp(maxSpawnRate, endSpawnRate, difficultyFactor); // ��������ŷ������������

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

            // �����´�����ʱ��
            PnextSpawnTime = Time.time + Random.Range(PminSpawnRate, PmaxSpawnRate);
        }
        */
    }

    void SpawnBubble()
    {
        // ���ѡ��һ�����ɵ�
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // �����ϰ���
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
