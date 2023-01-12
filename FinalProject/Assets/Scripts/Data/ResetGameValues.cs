using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private GameValues gameValues;
    // Start is called before the first frame update
    void Start()
    {
        gameValues.currentScene = "MainMenu";
        gameValues.levelIndex = 0;

    }
}
