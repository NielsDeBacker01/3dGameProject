using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public bool clicked = false;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void RepeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
 