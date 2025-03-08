//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    private Rigidbody2D rb;
//    private Vector2 moveDirection;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        rb.freezeRotation = true; // Prevents unwanted rotation
//        Debug.Log("PlayerMovement Start: " + gameObject.name);
//    }

//    void Update()
//    {
//        float moveX = Input.GetAxis("Horizontal");
//        float moveY = Input.GetAxis("Vertical");
//        moveDirection = new Vector2(moveX, moveY).normalized;
//    }

//    void FixedUpdate()
//    {
//        rb.linearVelocity = moveDirection * moveSpeed;
//        rb.angularVelocity = 0f; // Ensures no spinning
//    }

//    void OnDestroy()
//    {
//        Debug.Log("PlayerMovement Destroyed: " + gameObject.name);
//    }
//}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
        rb.angularVelocity = 0f;
    }

    void OnDestroy()
    {
        Debug.Log("PlayerMovement Destroyed: " + gameObject.name);
    }
}
