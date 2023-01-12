using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUIValues : MonoBehaviour
{
    [SerializeField]
    private UIValues UIValues;
    public bool UIState = false;
    // Start is called before the first frame update
    void Start()
    {
        UIValues.UIActive = UIState;
        UIValues.position = 0;
    }
}
