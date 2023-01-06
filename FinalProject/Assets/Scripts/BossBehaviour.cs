using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Teleport))]
[RequireComponent(typeof(HealthManager))]
public class BossBehaviour : MonoBehaviour
{

    public int TpCooldown;
    public int BulletSpeed;
    [Range(0, 90)]
    public int BulletSpread;
    public GameObject Bullet;

    int shootCooldown;
    Teleport tp;
    Vector3 middle;

    // Start is called before the first frame update
    void Start()
    {
        Bullet.GetComponent<ShootMovement>().Speed = this.BulletSpeed;
        tp = this.GetComponent(typeof(Teleport)) as Teleport;
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

        shootCooldown -= 1;
        if(shootCooldown == 0)
        {
            Vector3 target = GenerateTarget();
            for(int i = -BulletSpread; i <= BulletSpread; i += BulletSpread)
            {
                Shoot(i, target);
            }
        }
    }

    void Shoot(int angleShift, Vector3 target){
        GameObject bullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        bullet.transform.LookAt(target);

        //apply rotation for split bullet
        bullet.transform.Rotate(0, angleShift, 0);
    }

    Vector3 GenerateTarget(){
        return new Vector3(Random.Range((int)middle.x - middle.x/2, (int)middle.x + middle.x/2), 0 ,Random.Range((int)middle.z - middle.z/2, (int)middle.z + middle.z/2));
    }
}
