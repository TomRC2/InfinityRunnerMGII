using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float spawnZDistance = 30f;
    public float obstacleHeight = 1f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0) return;

        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(0f, 0f, spawnPoint.position.z + spawnZDistance);

        Instantiate(obstaclePrefabs[prefabIndex], spawnPos, Quaternion.identity);
    }
}