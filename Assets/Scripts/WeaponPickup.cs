using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // The weapon to give the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerR")) // Ensure the player has the correct tag
        {
            PlayerManager.Instance.PickUpWeapon(weaponPrefab);
            Destroy(gameObject); // Remove the pickup from the scene
        }
    }
}
