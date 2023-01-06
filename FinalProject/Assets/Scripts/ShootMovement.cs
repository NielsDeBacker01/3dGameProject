using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DoShoot = false;
    public float Speed = 1f;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DoShoot){
            rb.AddForce(gameObject.transform.forward * Speed);
        }
    }
}
