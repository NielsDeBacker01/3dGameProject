using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.CompleteLevel(); 
    }
}
