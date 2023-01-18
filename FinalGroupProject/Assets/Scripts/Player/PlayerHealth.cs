using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    HealthManager hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("bullet")){
            this.hp.currentHp--;
            Destroy(hit.gameObject);
        }
    }
}
