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


public interface IMovementPlan
{
    Vector2 CalculateMovement(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed);
}


public class BasicMovementPlan : IMovementPlan
{
    public Vector2 CalculateMovement(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed)
    {
        return moveDirection * moveSpeed;
    }
}


public class CustomMovementPlan : IMovementPlan
{
    public float acceleration = 5f;

    public Vector2 CalculateMovement(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed)
    {
        Vector2 movement = moveDirection * moveSpeed;
        
        rb.AddForce(movement * acceleration, ForceMode2D.Force);
        return movement;
    }
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private IMovementPlan movementStrategy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        
        movementStrategy = new BasicMovementPlan();
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        Vector2 movement = movementStrategy.CalculateMovement(rb, moveDirection, moveSpeed);
        rb.linearVelocity = movement;
        rb.angularVelocity = 0f;
    }

    void OnDestroy()
    {
        Debug.Log("PlayerMovement Destroyed: " + gameObject.name);
    }
}
