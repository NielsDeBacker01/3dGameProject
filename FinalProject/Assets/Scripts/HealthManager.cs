using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public bool showHP;
    public int maxHp;
    public int currentHp;
    public TextMeshProUGUI hpText;

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

        if(hpText != null)
        {
            if(showHP)
            {
                hpText.text = currentHp.ToString() + " / " + maxHp.ToString();
            }
            else
            {
                hpText.text = "";
            }
        } 
    }
}