using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickupSpawner : MonoBehaviour
{
    public int PickupCooldown;
    float cooldown;
    Vector3 middle;
    GameObject Ammo;
    GameObject currentItem;
    // Start is called before the first frame update
    void Start()
    { 
        Ammo = AssetDatabase.LoadAssetAtPath("Assets/Prefab/PickupAmmo.prefab", typeof(GameObject)) as GameObject; 
        middle = Terrain.activeTerrain.terrainData.size / 2;
        middle.y = 0;   
        middle.x -= Ammo.transform.localScale.x / 2;
        middle.z -= Ammo.transform.localScale.z / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentItem == null && cooldown <= 0)
        {
            currentItem = Instantiate(Ammo, middle, Quaternion.identity);
            cooldown = PickupCooldown;
        }
        else
        {
            cooldown -= Time.fixedDeltaTime;
        }
    }
}
