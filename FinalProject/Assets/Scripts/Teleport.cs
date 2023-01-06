using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int edgeMinX;
    public int edgeMaxX;
    public int edgeMinZ;
    public int edgeMaxZ;

    [HideInInspector]
    public int tpTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tpTimer += 1;
    }

    public void RandomTeleport(Vector3 lookat)
    {
        int x = Random.Range(edgeMinX - 15, edgeMaxX + 15);
        int z = Random.Range(edgeMinZ - 10, edgeMaxZ + 10);
        if( ( edgeMinX < x && x < edgeMaxX  ) && ( edgeMinZ < z && z < edgeMaxZ ) )
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