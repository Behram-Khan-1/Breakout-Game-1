
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField] private int health = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }

    }

    private void TakeDamage()
    {
        health--;

        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

}
