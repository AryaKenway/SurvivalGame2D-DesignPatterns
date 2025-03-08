using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public int health = 100;
    public GameObject gameOverUI;
    public Transform weaponHolder;
    private GameObject currentWeapon;

    private Rigidbody2D rb;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            return;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PickUpWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null) return;

        currentWeapon = Instantiate(weaponPrefab, weaponHolder.position, Quaternion.identity);
        currentWeapon.transform.SetParent(weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;

        health -= damage;
        Debug.Log("Player HP: " + health);

        if (health <= 0)
        {
            Debug.Log("Player Died!");
            gameOverUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}
