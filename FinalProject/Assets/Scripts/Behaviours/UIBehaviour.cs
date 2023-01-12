using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    // Update is called once per frame
    Canvas canvas;
    public UIValues ui;
    public UnityEvent myEvent;
    public bool gameUI = false;
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }
    void Update()
    {
        if(ui.UIActive)
        {
            this.canvas.enabled = !gameUI;
        }
        else
        {
            this.canvas.enabled = gameUI;
        }
    }

    public void executeEvent() {
        myEvent.Invoke();
    }
}
