using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float startingSpeed = 3;
    [SerializeField] private Vector2 direction = new Vector2(1f, 1f);
    private Rigidbody2D rb;
    public Transform ParentPaddle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ParentPaddle = this.gameObject.transform.parent;

        speed = startingSpeed;
    }

    public void Shoot(float dir)
    {
        DirectionSelector(dir);

        this.gameObject.transform.SetParent(null);
        rb.simulated = true;
        // Set the initial velocity of the ball
        rb.linearVelocity = direction * speed;
    }


    public void PaddleShot(float dir, bool isMoving)
    {
        // If the paddle is moving, adjust the direction based on the paddle's movement
        if (isMoving)
        {
            DirectionSelector(dir);
            rb.linearVelocity = direction * speed;
        }
        else
        {
            // If the paddle is not moving, keep the ball moving in the same direction
            direction = rb.linearVelocity.normalized;
        }

    }

    private void DirectionSelector(float dir)
    {
        if (dir > 0)
        {
            direction = new Vector2(0.35f, 1f);
        }
        else if (dir < 0)
            direction = new Vector2(-0.35f, 1f);
        else
            direction = new Vector2(0f, 1f);
    }

    public void IncreaseSpeed()
    {
        speed += 0.25f;
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    public void Reset()
    {
        gameObject.transform.SetParent(ParentPaddle);
        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;
        gameObject.transform.position = ParentPaddle.position + new Vector3(0f, 0.25f, 0f);
        speed = startingSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }


}
