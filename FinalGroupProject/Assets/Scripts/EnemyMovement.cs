using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    Rigidbody rb;
    public float speed = 10;
    public float multiplier = 10;
    public float speed_limit = 2;
    public float timer=8;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(player.transform);
        // Vector3 vel = rb.velocity;

        // if (vel.x > -speed_limit && vel.x < speed_limit && vel.z > -speed_limit && vel.z < speed_limit){
        //     rb.AddForce (speed * multiplier * Time.deltaTime * transform.forward, ForceMode.Acceleration);
        // }

        timer += Time.deltaTime;
        if (Mathf.Round(timer) % 4 == 0){
            transform.LookAt(player.transform);
        }
        
        if (timer > 4){
            transform.position += transform.forward * speed * multiplier * Time.deltaTime;
        } else if (timer > 8){
            transform.position += transform.forward * speed * Time.deltaTime;
            timer = 0;
        } else {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
