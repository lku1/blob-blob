using UnityEngine;

public class SpearSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpearData
    {
        public string spearName;
        public GameObject spearPrefab;
        [HideInInspector] public float timer;
        [HideInInspector] public float currentSpawnRate;
    }

    [Header("Spear Settings")]
    public SpearData[] spears;
    public float heightOffset = 10;

    [Header("Random Spawn Rate Limits")]
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 3f;

    void Start()
    {
        // Initialize every single spear with its own unique random timer.
        // NOTICE: spawnPipe() has been removed from here so nothing spawns immediately!
        for (int i = 0; i < spears.Length; i++)
        {
            if (spears[i].spearPrefab != null)
            {
                SetRandomSpawnRate(ref spears[i]);
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < spears.Length; i++)
        {
            if (spears[i].spearPrefab == null) continue;

            spears[i].timer += Time.deltaTime;

            if (spears[i].timer >= spears[i].currentSpawnRate)
            {
                spawnPipe(spears[i].spearPrefab);
                SetRandomSpawnRate(ref spears[i]);
                spears[i].timer = 0f;
            }
        }
    }

    void SetRandomSpawnRate(ref SpearData spear)
    {
        spear.currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    void spawnPipe(GameObject spearPrefab)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(spearPrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
