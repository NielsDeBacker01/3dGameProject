using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvent : MonoBehaviour
{
    public string nextLevel;
    public GameValues gameValues;
    // Start is called before the first frame update

    public void loadNextLevel(){
        gameValues.currentScene = nextLevel;
        SceneManager.LoadScene(gameValues.currentScene);
    }

    public void gameOver(){
        gameValues.currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOverScene");
    }
}
