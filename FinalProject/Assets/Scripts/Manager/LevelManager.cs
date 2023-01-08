using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static string currentScene;
    static int levelIndex;
    static bool UIActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOverScene"){
            if(Input.GetKeyDown(KeyCode.Return)){
                Reload();
            }
        } 
        else 
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                UIActive = (UIActive) ? false : true;
            }
        }
    }

    public static void GameOver(){
        SceneManager.LoadScene("GameOverScene");
        currentScene = SceneManager.GetActiveScene().name;
    }

    public static void Reload(){
        SceneManager.LoadScene(currentScene);
    }

    public static bool GetPause(){
        return UIActive;
    }
}
