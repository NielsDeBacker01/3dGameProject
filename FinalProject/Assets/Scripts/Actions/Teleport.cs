using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int edgeMinX;
    public int edgeMaxX;
    public int edgeMinZ;
    public int edgeMaxZ;
    public int xDeadzone;
    public int zDeadzone;

    [HideInInspector]
    public float tpTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tpTimer += Time.fixedDeltaTime;
    }

    public void RandomTeleport(Vector3 lookat)
    {
        int x = Random.Range(edgeMinX, edgeMaxX);
        int z = Random.Range(edgeMinZ, edgeMaxZ);
        if( ( edgeMinX + xDeadzone < x && x < edgeMaxX - xDeadzone ) && ( edgeMinZ + zDeadzone < z && z < edgeMaxZ - zDeadzone) )
        {
            RandomTeleport(lookat);
        } 
        else
        {
            gameObject.transform.position = new Vector3(x, 0, z);
            if(lookat != null){
                gameObject.transform.LookAt(lookat);
            }
            tpTimer = 0;
        }
    }
}