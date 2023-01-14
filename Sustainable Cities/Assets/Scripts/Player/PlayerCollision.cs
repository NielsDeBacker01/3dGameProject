using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private int health = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
            health--;

        if (health <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
