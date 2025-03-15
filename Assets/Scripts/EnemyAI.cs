//using UnityEngine;

//public class EnemyAI : MonoBehaviour
//{
//    public float moveSpeed = 3f;
//    public int health = 30;
//    public WaveManager waveManager;

//    private Transform player;
//    private Rigidbody2D rb;

//    void Start()
//    {
//        FindPlayer();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void FixedUpdate()
//    {
//        if (player != null)
//        {
//            MoveTowardsPlayer();
//        }
//    }

//    private void FindPlayer()
//    {
//        GameObject playerObj = GameObject.FindGameObjectWithTag("PlayerR");
//        player = playerObj != null ? playerObj.transform : null;

//        if (player == null)
//        {
//            Debug.LogError("EnemyAI: No GameObject found with tag 'PlayerR'");
//        }
//    }

//    private void MoveTowardsPlayer()
//    {
//        Vector2 direction = (player.position - transform.position).normalized;
//        rb.linearVelocity = direction * moveSpeed;
//    }

//    public void TakeDamage(int damage)
//    {
//        health -= damage;
//        if (health <= 0)
//        {
//            Die();
//        }
//    }

//    private void Die()
//    {
//        FindFirstObjectByType<WaveManager>().EnemyDefeated();
//        Destroy(gameObject);
//    }
//}

using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public float moveSpeed = 3f;
    public int health = 30;
    public WaveManager waveManager;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        FindPlayer();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("PlayerR");
        player = playerObj != null ? playerObj.transform : null;

        if (player == null)
        {
            Debug.LogError("EnemyAI: No GameObject found with tag 'PlayerR'");
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (WaveManager.Instance != null)
        {
            WaveManager.Instance.EnemyDefeated();
        }
        else
        {
            Debug.LogError("WaveManager instance is null. Ensure it is active in the scene.");
        }
        Destroy(gameObject);
    }

}
