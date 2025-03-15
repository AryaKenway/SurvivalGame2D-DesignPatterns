//using UnityEngine;
//using System.Collections;

//public class WeaponAttack : MonoBehaviour
//{
//    public float attackRange = 2f;
//    public LayerMask enemyLayer;
//    public GameObject bulletPrefab;
//    public Transform firePoint;
//    public float bulletSpeed = 10f;

//    public Transform gunTransform;
//    public Transform swordTransform;
//    public float swordRotationSpeed = 720f;
//    public float attackDuration = 0.2f;

//    void Update()
//    {
//        RotateGunToMouse();

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            StartCoroutine(RotateSword());
//            MeleeAttack();
//        }

//        if (Input.GetMouseButtonDown(0))
//        {
//            Shoot();
//        }
//    }

//    void RotateGunToMouse()
//    {
//        if (gunTransform == null) return;

//        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Vector3 direction = mousePos - gunTransform.position;
//        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//        gunTransform.rotation = Quaternion.Euler(0, 0, angle);
//    }

//    IEnumerator RotateSword()
//    {
//        Vector3 pivotPoint = swordTransform.parent.position;
//        float startAngle = swordTransform.localEulerAngles.z;
//        float targetAngle = startAngle + 70f; // Reduced angle for closer attack arc

//        float elapsedTime = 0f;
//        while (elapsedTime < attackDuration)
//        {
//            float angle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / attackDuration);
//            swordTransform.RotateAround(pivotPoint, Vector3.forward, angle - swordTransform.localEulerAngles.z);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        swordTransform.rotation = Quaternion.identity;
//    }


//    void MeleeAttack()
//    {
//        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordTransform.position, attackRange, enemyLayer);
//        foreach (Collider2D enemy in hitEnemies)
//        {
//            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
//            if (enemyAI != null)
//            {
//                enemyAI.TakeDamage(30);
//            }
//        }
//    }

//    void Shoot()
//    {
//        if (bulletPrefab == null || firePoint == null) return;

//        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//        rb.linearVelocity = firePoint.right * bulletSpeed;
//        Destroy(bullet, 2f);
//    }
//}


using UnityEngine;
using System.Collections;


public interface IMeleeAttack
{
    void MeleeAttack();
}

public interface IRangedAttack
{
    void Shoot();
}

public class WeaponAttack : MonoBehaviour, IMeleeAttack, IRangedAttack
{
    public float attackRange = 2f;
    public LayerMask enemyLayer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    public Transform gunTransform;
    public Transform swordTransform;
    public float swordRotationSpeed = 720f;
    public float attackDuration = 0.2f;

    void Update()
    {
        RotateGunToMouse();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateSword());
            MeleeAttack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); 
        }
    }

    void RotateGunToMouse()
    {
        if (gunTransform == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator RotateSword()
    {
        Vector3 pivotPoint = swordTransform.parent.position;
        float startAngle = swordTransform.localEulerAngles.z;
        float targetAngle = startAngle + 70f; 

        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            float angle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / attackDuration);
            swordTransform.RotateAround(pivotPoint, Vector3.forward, angle - swordTransform.localEulerAngles.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        swordTransform.rotation = Quaternion.identity;
    }

    
    public void MeleeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordTransform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(30);
            }
        }
    }

   
    public void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed; 
        Destroy(bullet, 2f);
    }
}
