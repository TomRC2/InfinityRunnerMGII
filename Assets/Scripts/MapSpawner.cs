using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnGround", 0f, spawnInterval);
    }

    void SpawnGround()
    {
        Vector3 spawnPos = spawnPoint.position;
        Instantiate(groundPrefab, spawnPos, Quaternion.identity);
    }
}