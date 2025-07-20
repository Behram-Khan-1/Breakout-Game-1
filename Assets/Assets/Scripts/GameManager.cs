using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    // Reference to the ball
    [SerializeField] private Ball ball;
    // Reference to the paddle
    [SerializeField] private Paddle paddle;

    int score = 0;
    int life = 3;
    [SerializeField] private bool isBallShot = false;


    public List<GameObject> hearts;
    public TextMeshProUGUI ScoreUI;

    // Awake is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallShot)
        {
            ball.Shoot(paddle.GetPlayerMovementDirection());
            isBallShot = true;
        }
    }


    public void ResetPositions()
    {
        // Reset the ball and paddle positions
        ball.Reset();
        paddle.Reset();
        isBallShot = false;
    }
    public void DecreaseLife()
    {
        life--;
        Debug.Log("Life: " + life);
        if (life <= 0)
        {
            Debug.Log("Game Over");
            RestartGame();
        }

        Destroy(hearts[hearts.Count - 1]);
        hearts.RemoveAt(hearts.Count - 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore()
    {
        score++;

        if (score % 5 == 0)
        {
            paddle.DecreaseSize();
        }
        ScoreUI.text = score.ToString();

        Debug.Log("Score: " + score);
    }

    public float GetPaddleDirection()
    {
        return paddle.GetPlayerMovementDirection();
    }
    public bool IsPaddleMoving()
    {
        return paddle.IsMoving();
    }



}
