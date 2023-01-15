using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPart : MonoBehaviour
{
    public void LoadNextPart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
