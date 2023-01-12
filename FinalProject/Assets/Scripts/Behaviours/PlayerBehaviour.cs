using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(ShootScript))]
[RequireComponent(typeof(MouseTracker))]
public class PlayerBehaviour : MonoBehaviour
{
    HealthManager hp;
    ShootScript shoot;
    MouseTracker mouse;
    public int ShootCooldown;
    int shootCooldown;
    private bool shotted;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
        shoot = this.GetComponent(typeof(ShootScript)) as ShootScript;
        shootCooldown = 0;
        mouse = this.GetComponent(typeof(MouseTracker)) as MouseTracker;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(shootCooldown <= 0)
            {
                shotted = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shotted)
        {
            if(shoot.Shoot(0, mouse.GetMouse(), "Friendly"))
            {
                shootCooldown = ShootCooldown;
            }
            shotted = false;
        }

        shootCooldown -= 1;
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("Deadly")){
            this.hp.currentHp--;
            Destroy(hit.gameObject);
        }

        if(hit.transform.gameObject.tag.Contains("Ammo")){
            this.shoot.currentBullets += hit.GetComponent<PickupBehaviour>().ammoCount;
            Destroy(hit.gameObject);
        }
    }
}
