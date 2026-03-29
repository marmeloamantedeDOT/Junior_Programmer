using UnityEngine;

public class SpawnManagerprop4 : MonoBehaviour
{
    public GameObject enemeyPrefab;
    private float spawnRange = 9;
   public int  waveNumber =1;
    public GameObject powerupPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(enemeyPrefab, GenerateSpawnPosition(), enemeyPrefab.transform.rotation);
    }

    // Update is called once per frame
    public int enemyCount;
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0) { 
            waveNumber++; 
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemeyPrefab, GenerateSpawnPosition(), enemeyPrefab.transform.rotation);
        }
    }
}

