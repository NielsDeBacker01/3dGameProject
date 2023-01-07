using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootMovement))]
public class BulletBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x < -100 || this.transform.position.x > 100 || this.transform.position.z < -100 || this.transform.position.z > 100) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hit){
        if((hit.transform.gameObject.tag.Contains("Player") && gameObject.tag == "Deadly") || (hit.transform.gameObject.tag.Contains("Boss") && gameObject.tag == "Friendly")){
            Destroy(gameObject);
        }
    }
}
