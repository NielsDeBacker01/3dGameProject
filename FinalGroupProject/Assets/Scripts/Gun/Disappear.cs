using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float lifetime=4;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer<lifetime)
        {
            timer += Time.deltaTime;
        }
        else
        {

            Destroy(gameObject);
        }
    }
}
