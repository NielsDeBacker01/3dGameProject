using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static string currentScene;
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
    }

    public static void GameOver(){
        SceneManager.LoadScene("GameOverScene");
        currentScene = SceneManager.GetActiveScene().name;
    }

    public static void Reload(){
        SceneManager.LoadScene(currentScene);
    }
}
