using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    public float restartDelay;
    public GameObject part1CompleteUI;

    public void CompleteLevel()
    {
        part1CompleteUI.SetActive(true);
    }

    public void GameOver()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
