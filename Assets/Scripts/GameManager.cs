//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro; // For TextMeshPro UI

//public class GameManager : MonoBehaviour
//{
//    public static GameManager Instance;
//    public EnvironmentManager environmentManager;
//    public WaveManager waveManager;
//    public PlayerManager playerManager;
//    public EnemyManager enemyManager;

//    public GameObject gameOverUI; // Assign in Inspector

//    void Awake()
//    {
//        if (Instance == null)
//            Instance = this;
//        else
//            Destroy(gameObject);
//    }

//    void Start()
//    {
//        StartCoroutine(WaveManager.Instance.StartWave());
//    }

//    public void GameOver()
//    {
//        Debug.Log("Game Over!");
//        gameOverUI.SetActive(true); // Show Game Over UI
//        Time.timeScale = 0; // Pause game
//    }

//    public void RestartGame()
//    {
//        Time.timeScale = 1; // Resume game
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
//    }
//}


using UnityEngine;
using UnityEngine.SceneManagement;

public interface IGameUIManager
{
    void ShowGameOverUI();
    void HideGameOverUI();
}



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public EnvironmentManager environmentManager;
    public WaveManager waveManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;

    private IGameUIManager gameUIManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
        gameUIManager = FindFirstObjectByType<GameUIManager>();

        StartCoroutine(WaveManager.Instance.StartWave());
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameUIManager.ShowGameOverUI(); 
        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}


public class GameUIManager : MonoBehaviour, IGameUIManager
{
    public GameObject gameOverUI; 

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true); 
    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false); 
    }
}

