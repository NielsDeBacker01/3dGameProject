using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    public GameValues gameValues;
    public UIValues UIValues;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOverScene"){
            if(Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(gameValues.currentScene);
            }
        }
        else if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if(Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(gameValues.currentScene);
            }
        } 
        else 
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                UIValues.UIActive = (UIValues.UIActive) ? false : true;
            }
        }
    }
}
