using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    // Update is called once per frame
    TextMeshProUGUI tmp;
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(LevelManager.GetPause())
        {
            tmp.enabled = true;
        }
        else
        {
            tmp.enabled = false;
        }
    }
}
