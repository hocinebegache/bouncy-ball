using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject bullet;
    public int enemyCount;
    public int waveNumber = 1;
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }

        bullet.transform.position = new Vector3(enemyPrefab[RandomEnemy()].transform.position.x, enemyPrefab[RandomEnemy()].transform.position.z, enemyPrefab[RandomEnemy()].transform.position.y);
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
            Instantiate(enemyPrefab[RandomEnemy()], GenerateSpawnPosition(), enemyPrefab[RandomEnemy()].transform.rotation);
            Instantiate(bullet, GenerateSpawnPosition(), bullet.transform.rotation);
        }

    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private int RandomEnemy ()
    {
        int randEnemy = Random.Range(0,2);
        return randEnemy;
    }

}
