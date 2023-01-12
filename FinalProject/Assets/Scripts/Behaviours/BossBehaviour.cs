using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Teleport))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(ShootScript))]
public class BossBehaviour : MonoBehaviour
{

    public float TpCooldown;
    [Range(0, 90)]
    public int BulletSpread;
    float shootCooldown;
    HealthManager hp;
    Teleport tp;
    ShootScript shoot;
    Vector3 middle;

    // Start is called before the first frame update
    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
        tp = this.GetComponent(typeof(Teleport)) as Teleport;
        shoot = this.GetComponent(typeof(ShootScript)) as ShootScript;
        middle = Terrain.activeTerrain.terrainData.size / 2;
        middle.y = 0;
        shootCooldown = TpCooldown / 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TpCooldown <= tp.tpTimer)
        {
            tp.RandomTeleport(middle);
            shootCooldown = TpCooldown / 3;
        }

        if(shootCooldown <= 0)
        {
            Vector3 target = GenerateTarget();
            for(int i = -BulletSpread; i <= BulletSpread; i += BulletSpread)
            {
                shoot.Shoot(i, target, "Deadly");
                shootCooldown = TpCooldown * (2f/(18 - ( 3 * (Mathf.Floor((this.hp.currentHp - 1) / 10f) + 1))));
            }
        }

        shootCooldown -= Time.fixedDeltaTime;
    }

    Vector3 GenerateTarget(){
        return new Vector3(Random.Range((int)(middle.x - middle.x * 0.75), (int)(middle.x + middle.x * 0.75)), 0 ,Random.Range((int)(middle.z - middle.z * 0.75), (int)(middle.z + middle.z * 0.75)));
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("Friendly")){
            this.hp.currentHp--;
            if(this.hp.currentHp % 10 == 0)
            this.shoot.BulletSpeed -= 5;
            Destroy(hit.gameObject);
        }
    }
}
