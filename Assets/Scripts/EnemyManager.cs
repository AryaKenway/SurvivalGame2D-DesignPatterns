//using UnityEngine;

//public class EnemyManager : MonoBehaviour
//{
//    public GameObject enemyPrefab;
//    public Transform[] spawnPoints;

//    public void SpawnEnemies(int count)
//    {
//        if (spawnPoints.Length == 0 || enemyPrefab == null) return;

//        for (int i = 0; i < count; i++)
//        {
//            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
//            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

//            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
//            if (enemyAI != null)
//            {
//                enemyAI.waveManager = WaveManager.Instance;
//            }
//        }
//    }
//}
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1; // New prefab reference
    public Transform[] spawnPoints;

    //public void SpawnEnemies(int count)
    //{
    //    if (spawnPoints.Length == 0 || (enemyPrefab == null && enemyPrefab1 == null)) return;

    //    for (int i = 0; i < count; i++)
    //    {
    //        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
    //        GameObject chosenPrefab = Random.value < 0.5f ? enemyPrefab : enemyPrefab1; // Randomly pick one
    //        GameObject enemy = Instantiate(chosenPrefab, spawnPoint.position, spawnPoint.rotation);

    //        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
    //        if (enemyAI != null)
    //        {
    //            enemyAI.waveManager = WaveManager.Instance;
    //        }
    //    }
    //}
    public void SpawnEnemies(int count)
    {
        if (spawnPoints.Length == 0 || (enemyPrefab == null && enemyPrefab1 == null)) return;

        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Randomly select between enemyPrefab and enemyPrefab2
            GameObject selectedPrefab = Random.value < 0.5f ? enemyPrefab : enemyPrefab1;

            Vector3 offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            GameObject enemy = Instantiate(selectedPrefab, spawnPoint.position + offset, spawnPoint.rotation);

            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.waveManager = WaveManager.Instance;
            }
        }
    }

}
