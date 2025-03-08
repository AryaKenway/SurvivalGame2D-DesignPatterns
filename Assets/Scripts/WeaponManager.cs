using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public int damage = 10;

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PlayerManager.Instance.transform.position, 2f, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}