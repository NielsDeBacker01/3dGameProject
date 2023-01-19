using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 3;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            GetComponent<Part1Movement>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
