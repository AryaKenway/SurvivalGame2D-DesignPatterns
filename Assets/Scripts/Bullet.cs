//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public int damage = 20;

//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Gun")) return;

//        if (collision.CompareTag("Enemy"))
//        {
//            EnemyAI enemy = collision.GetComponent<EnemyAI>();
//            if (enemy != null)
//            {
//                enemy.TakeDamage(damage);
//                Destroy(gameObject);
//            }
//        }
//    }
//}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gun")) return;

        if (collision.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
