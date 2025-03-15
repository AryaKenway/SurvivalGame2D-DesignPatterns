using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerR")) 
        {
            PlayerManager.Instance.PickUpWeapon(weaponPrefab);
            Destroy(gameObject);
        }
    }
}
