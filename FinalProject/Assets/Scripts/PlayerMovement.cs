using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float TimeScale = 1f;
    public float speed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //get base input
        Vector3 direction = new Vector3(0,0);
        if(Input.GetKey(KeyCode.DownArrow)){
            direction.z += -1;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            direction.z += 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            direction.x += -1;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            direction.x += 1;
        }

        //correct borders (if outside frame -> correct)
        transform.Translate(direction * speed * TimeScale);
        print(direction * speed * TimeScale);
    }
}