using UnityEngine;
using System.Collections;

public interface IBackgroundManager
{
    void StartCycle(MonoBehaviour host);
}

public interface IObjectSpawner
{
    void SpawnObjects();
}

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    [Header("Background Settings")]
    public SpriteRenderer background;
    public Color dayColor = Color.white;
    public Color nightColor = Color.black;
    public float transitionDuration = 5f;

    [Header("Sprite Spawning")]
    public GameObject[] spawnPrefabs;
    public int numberOfObjects = 10;

    private IBackgroundManager backgroundManager;
    private IObjectSpawner objectSpawner;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        backgroundManager = new BackgroundManager(background, dayColor, nightColor, transitionDuration);
        objectSpawner = new ObjectSpawner(spawnPrefabs, numberOfObjects);
    }

    private void Start()
    {
        backgroundManager.StartCycle(this);
        objectSpawner.SpawnObjects();
    }
}

public class BackgroundManager : IBackgroundManager
{
    private SpriteRenderer background;
    private Color dayColor;
    private Color nightColor;
    private float transitionDuration;

    public BackgroundManager(SpriteRenderer bg, Color day, Color night, float duration)
    {
        background = bg;
        dayColor = day;
        nightColor = night;
        transitionDuration = duration;
    }

    public void StartCycle(MonoBehaviour host)
    {
        host.StartCoroutine(DayNightCycle());
    }

    private IEnumerator DayNightCycle()
    {
        while (true)
        {
            yield return ChangeBackgroundColor(dayColor, nightColor);
            yield return new WaitForSeconds(10f);
            yield return ChangeBackgroundColor(nightColor, dayColor);
            yield return new WaitForSeconds(10f);
        }
    }

    private IEnumerator ChangeBackgroundColor(Color from, Color to)
    {
        float elapsed = 0f;
        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            background.color = Color.Lerp(from, to, elapsed / transitionDuration);
            yield return null;
        }
        background.color = to;
    }
}

public class ObjectSpawner : IObjectSpawner
{
    private GameObject[] spawnPrefabs;
    private int numberOfObjects;

    public ObjectSpawner(GameObject[] prefabs, int number)
    {
        spawnPrefabs = prefabs;
        numberOfObjects = number;
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-5f, 5f);
            Vector2 spawnPosition = new Vector2(x, y);

            GameObject prefabToSpawn = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];
            Object.Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
