//using UnityEngine;
//using System.Collections;

//public class WaveManager : MonoBehaviour
//{
//    public static WaveManager Instance;
//    public EnemyManager enemyManager;
//    public int currentWave = 1;
//    public float waveInterval = 5f;
//    private int enemiesAlive = 0;

//    void Awake()
//    {
//        if (Instance == null)
//            Instance = this;
//        else
//            Destroy(gameObject);
//    }

//    void Start()
//    {
//        StartCoroutine(StartWave());
//    }

//    public IEnumerator StartWave()
//    {
//        while (true)
//        {
//            Debug.Log("Wave " + currentWave + " starting...");
//            enemiesAlive = currentWave * 10;

//            enemyManager.SpawnEnemies(enemiesAlive); // Spawn all at once

//            while (enemiesAlive > 0)
//            {
//                yield return null;
//            }

//            yield return new WaitForSeconds(waveInterval);
//            currentWave++;
//        }
//    }


//    public void EnemyDefeated()
//    {
//        enemiesAlive--;
//        if (enemiesAlive <= 0)
//        {
//            StartCoroutine(StartWave()); // Continue to the next wave
//        }
//    }

//}






using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public EnemyManager enemyManager;
    public int currentWave = 1;
    public float waveInterval = 5f;
    private int enemiesAlive = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(StartWave());
    }

    public IEnumerator StartWave()
    {
        while (true)
        {
            StartWaveCycle();
            yield return WaitUntilWaveEnd();
            yield return new WaitForSeconds(waveInterval);
            AdvanceWave();
        }
    }

    private void StartWaveCycle()
    {
        Debug.Log("Wave " + currentWave + " starting...");
        enemiesAlive = currentWave * 10;
        enemyManager.SpawnEnemies(enemiesAlive);
    }

    private IEnumerator WaitUntilWaveEnd()
    {
        while (enemiesAlive > 0)
        {
            yield return null;
        }
    }

    private void AdvanceWave()
    {
        currentWave++;
    }

    public void EnemyDefeated()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
           
        }
    }
}
