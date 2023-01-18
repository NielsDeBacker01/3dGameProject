using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    HealthManager hp;
    public GameObject player;
    Rigidbody rb;
    public float speed = 10;
    public float multiplier = 10;
    public float timer = 0f;
    public float delay;
    public float chargeTime;

    public float idleTurnSpeed = 10;
    public float chargeTurnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
        rb = GetComponent<Rigidbody>();
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= delay && timer < (delay + chargeTime/1.75)){
            transform.position += transform.forward * speed * multiplier * Time.deltaTime;
        } else if(timer >= delay && timer > (delay + chargeTime/3) && timer < (delay + chargeTime)){
            SmoothLookAtPlayer(chargeTurnSpeed);
            transform.position += transform.forward * speed * multiplier/2 * Time.deltaTime;
        }else if (timer >= (delay + 1)){
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            timer = 0f;
        } else {
        // Smoothly rotate towards Player
        SmoothLookAtPlayer(idleTurnSpeed);
        }
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("bullet")){
            this.hp.currentHp--;
            Destroy(hit.gameObject);
        }
    }

    void SmoothLookAtPlayer(float turnspeed){
        Vector3 dir = player.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnspeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
