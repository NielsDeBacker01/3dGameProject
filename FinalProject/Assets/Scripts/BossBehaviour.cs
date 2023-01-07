using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Teleport))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(ShootScript))]
public class BossBehaviour : MonoBehaviour
{

    public int TpCooldown;
    [Range(0, 90)]
    public int BulletSpread;

    int shootCooldown;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(TpCooldown <= tp.tpTimer)
        {
            tp.RandomTeleport(middle);
            shootCooldown = TpCooldown / 2;
        }

        if(shootCooldown == 0)
        {
            Vector3 target = GenerateTarget();
            for(int i = -BulletSpread; i <= BulletSpread; i += BulletSpread)
            {
                shoot.Shoot(i, target, "Deadly");
                shootCooldown = TpCooldown / 4;
            }
        }
        shootCooldown -= 1;
    }

    Vector3 GenerateTarget(){
        return new Vector3(Random.Range((int)middle.x - middle.x/2, (int)middle.x + middle.x/2), 0 ,Random.Range((int)middle.z - middle.z/2, (int)middle.z + middle.z/2));
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("Friendly")){
            this.hp.currentHp--;
        }
    }
}
