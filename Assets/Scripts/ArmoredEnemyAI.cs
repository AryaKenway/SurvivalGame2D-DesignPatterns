using UnityEngine;

public class ArmoredEnemyAI : EnemyAI
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage / 2);
        Debug.Log("Armored enemy took reduced damage.");
    }
}
