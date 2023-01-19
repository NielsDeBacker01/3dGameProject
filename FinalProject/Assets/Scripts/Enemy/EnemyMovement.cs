using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public float forwardForce;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.z >= 100)
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (transform.position.z >= player.position.z)
        {
            FindObjectOfType<Part1Movement>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
