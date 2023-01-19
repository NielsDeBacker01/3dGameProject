using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    public float restartDelay;
    public GameObject part1CompleteUI;
    public GameObject failUI;

    public void CompleteLevel()
    {
        part1CompleteUI.SetActive(true);
    }


    public void GameOver()
    {
        if (gameOver == false)
        {
            failUI.SetActive(true);
            gameOver = true;
        }
    }

    public void Start()
    {
        Time.fixedDeltaTime = 0.01f;
    }
}
