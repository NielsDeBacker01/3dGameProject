using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(LevelEvent))]
public class HealthManager : MonoBehaviour
{
    public bool showHP;
    public int maxHp;
    public int currentHp;
    public TextMeshProUGUI hpText;
    public string pretext;
    LevelEvent levelEvent; 

    void Start()
    {
        levelEvent = this.GetComponent(typeof(LevelEvent)) as LevelEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHp > maxHp){
            currentHp = maxHp;
        }

        if(currentHp <= 0){
            if(gameObject.tag.Contains("Player")){
                levelEvent.gameOver();
            }
            else if(gameObject.tag.Contains("Boss") || gameObject.tag.Contains("enemy"))
            {
                levelEvent.loadNextLevel();
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
                hpText.enabled = true;
                hpText.text = pretext + "HP: " + currentHp.ToString() + " / " + maxHp.ToString();
            }
            else
            {
                hpText.enabled = false;
            }
        } 
    }
}