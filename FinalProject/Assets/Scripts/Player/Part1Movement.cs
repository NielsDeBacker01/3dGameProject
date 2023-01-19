using UnityEngine;

public class Part1Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;

    // Update is called once per frame
    void FixedUpdate()
    {
        // go forward
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // go left and right
        if (Input.GetKey("d"))
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("a"))
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (transform.position.y <= -10)
        {
            GetComponent<Part1Movement>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
