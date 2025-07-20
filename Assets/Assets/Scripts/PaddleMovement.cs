using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float decreaseAmount = 0.1f;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        // Call the Movement method in FixedUpdate for physics calculations
        Movement();
    }

    private void Movement()
    {
        // Get input from the user
        movement.x = Input.GetAxisRaw("Horizontal");
        // Move the paddle based on input
        rb.linearVelocity = movement * speed;
        // Check if the paddle is moving
        if (movement.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public float GetPlayerMovementDirection()
    {
        // Return the direction of the paddle movement
        return movement.x;
    }

    public void Reset()
    {
        gameObject.transform.position = new Vector2(0f, -4f);
    }

    public void DecreaseSize()
    {
        transform.localScale = transform.localScale - new Vector3(0, decreaseAmount, 0);
    }
    public bool IsMoving()
    {
        // Return true if the paddle is moving, false otherwise
        return isMoving;
    }
}