using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Audio.ProcessorInstance;

public class Enemymovement : MonoBehaviour
{
    public GameObject Enemy;
    //public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    [Header("Random Spawn Rate Limits")]
    public float minSpawnRate = 1f;  // Minimum time between spawns
    public float maxSpawnRate = 3f;  // Maximum time between spawns
    private float currentSpawnRate;  // The active random target time


    void Start()
    {
        // Pick the first random spawn rate right when the game starts
        SetRandomSpawnRate();
    }

    void Update()
    {
        // Count up until you hit the random target rate
        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            SetRandomSpawnRate(); // Pick a new random delay for the next enemy
            timer = 0;
        }
    }

    void SetRandomSpawnRate()
    {
        // Pick a random float between your min and max limits
        currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    void spawnEnemy()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}