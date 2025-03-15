using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
}

public class WeaponManager : MonoBehaviour
{
    public int damage = 10;

    public void Attack()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(PlayerManager.Instance.transform.position, 2f, LayerMask.GetMask("Enemy"));
        foreach (Collider2D obj in hitObjects)
        {
            IDamageable damageable = obj.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
