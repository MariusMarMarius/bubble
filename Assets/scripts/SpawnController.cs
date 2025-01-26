using UnityEngine;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{

    [Header("Combination")]
    public GameObject[] combinationPrefabs;

    [Header("Cloud")]
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;


    [Header("BubbleSachen")]
    public GameObject bubblePrefab;


    [Header("PlatformSachen")]
    public GameObject[] obstaclePrefabs;


    [Header("Coin")]
    public GameObject coinPrefab;

    private int score;

    public Transform createNewAnchor;
    
    private void spawnNextCombination(Combination lastCombination)
    {
        List<GameObject> filteredCombinations = new List<GameObject>();
        foreach (GameObject g in combinationPrefabs)
        {
            if (lastCombination.exitL == g.GetComponent<Combination>().entryL)
            {
                filteredCombinations.Add(g);
            }
        }

        int selectedIndex = Random.Range(0, filteredCombinations.Count);
        GameObject selectedComb = filteredCombinations[selectedIndex];

        GameObject newCombination = Instantiate(selectedComb, new Vector2(createNewAnchor.position.x, selectedComb.transform.position.y), Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Combination"))
        {
            spawnNextCombination(collision.gameObject.GetComponentInParent<Combination>());
        }
    }

    void SpawnBubble()
    {
        // 随机选择一个生成点
        //int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        //Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        // 生成障碍物
        //GameObject newBubble = Instantiate(bubblePrefab, chosenSpawnPoint.position, Quaternion.identity);
        
        //newBubble.GetComponent<Bubble>().Setup(GameplayColor.WHITE, 0.5f);
    }

    

    void SpawnPlatform()
    {/*
        int prefabIndex = UnityEngine.Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenPrefab = obstaclePrefabs[prefabIndex];

        int spawnIndex = UnityEngine. Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[spawnIndex];

        GameObject newPlatform = Instantiate(chosenPrefab, chosenSpawnPoint.position, Quaternion.identity);*/
    }
}
