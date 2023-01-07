using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShootScript : MonoBehaviour
{
    GameObject Bullet;
    public int BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        Bullet = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Bullet.prefab", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot(int angleShift, Vector3 target, string tag){
        GameObject bullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        
        bullet.GetComponent<ShootMovement>().Speed = this.BulletSpeed;
        //aim
        bullet.transform.LookAt(target);

        //apply rotation for split bullet
        bullet.transform.Rotate(0, angleShift, 0);

        //apply tag
        bullet.tag = tag;
    }
}