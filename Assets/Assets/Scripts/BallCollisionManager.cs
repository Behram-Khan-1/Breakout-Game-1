using Unity.VisualScripting;
using UnityEngine;

public class BallCollisionManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject BottomWall;

    void Start()
    {
        ball = GetComponent<Ball>();


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            ball.IncreaseSpeed();
            GameManager.instance.IncreaseScore();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            ball.PaddleShot(GameManager.instance.GetPaddleDirection(),
                            GameManager.instance.IsPaddleMoving() );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == BottomWall)
        {
            Debug.Log("Ball hit the bottom wall, restarting game.");
            GameManager.instance.ResetPositions();
            GameManager.instance.DecreaseLife();
        }
    }
}
