using UnityEngine;
using UnityEngine.UI;

public class ReachGoal : MonoBehaviour
{
    public Transform player;
    public Text text;
    private float untilGoal = 1000;

    // Update is called once per frame
    void Update()
    {
        if (untilGoal > 0)
            untilGoal = 1000 - player.position.z;
        else
            untilGoal = 0;

        text.text = untilGoal.ToString("0") + " m";
    }
}
