using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsEvent : MonoBehaviour
{
    public UIValues ui;
    public void loadOptions(){
        ui.UIActive = !ui.UIActive;
        if(ui.UIActive)
        {
            
        }
    }
}
