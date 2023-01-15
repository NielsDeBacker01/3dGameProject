using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public bool clicked = false;

    public void RepeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
 