using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
   public string waveName;
   public int noOFEnemies;
   public GameObject[] typeOFEnemies;
   public float spawnInterval;
}
public class Wavesystem : MonoBehaviour
{
   [SerializeField] Wave[] waves;
   public Transform[] spawnPoints;

   private Wave currentWave;
   private int currentWaveNumber;
   private float nextSpawnTime;
  
   private bool canSpawn = true;

private void Update()
{
  currentWave = waves[currentWaveNumber];
  SpawnWave();
  GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
  if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
  {
    currentWaveNumber++;
    canSpawn = true;
  }
}
void SpawnNextWave()
{
   currentWaveNumber++;
    canSpawn = true;
}
   void SpawnWave()
   {
     if (canSpawn && nextSpawnTime < Time.time)
    {
      GameObject randomEnemy = currentWave.typeOFEnemies[Random.Range(0,currentWave.typeOFEnemies.Length)];
      Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
      Instantiate(randomEnemy,randomPoint.position, Quaternion.identity);
      currentWave.noOFEnemies --;
      nextSpawnTime = Time.time + currentWave.spawnInterval;
      if (currentWave.noOFEnemies == 0)
        {
          canSpawn = false;
        }
   }
   }
}