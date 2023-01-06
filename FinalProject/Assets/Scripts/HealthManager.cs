using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHp;
    public int currentHp;

    // Update is called once per frame
    void Update()
    {
        if(currentHp > maxHp){
            currentHp = maxHp;
        }

        if(currentHp <= 0){
            if(gameObject.tag.Contains("Player")){
                LevelManager.GameOver();
            }
            else
            {
                GameObject.Destroy(gameObject);
            }   
        }
    }

    
}
