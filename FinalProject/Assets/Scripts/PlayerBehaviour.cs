using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class PlayerBehaviour : MonoBehaviour
{
    HealthManager hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit){
        if(hit.transform.gameObject.tag.Contains("Deadly")){
            this.hp.currentHp--;
        }
    }
}
