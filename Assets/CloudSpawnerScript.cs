using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject[] clouds;
    public float minSpawnRate = 8f; // Minimum gap
    public float maxSpawnRate = 15f; // Maximum gap
    private float timer = 0;
    private float currentSpawnRate;
    public float heightOffset = 8f;

    void Start()
    {
        currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        spawnCloud();
    }

    void Update()
    {
        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            timer = 0;
            // Pick a new random time for the NEXT cloud
            currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        int randomIndex = Random.Range(0, clouds.Length);

        Instantiate(clouds[randomIndex], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}