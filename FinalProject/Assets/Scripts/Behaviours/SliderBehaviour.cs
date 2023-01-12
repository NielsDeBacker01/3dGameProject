using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBehaviour : MonoBehaviour
{
    public GameValues gameValues;
    public void OnSliderChange(float value){
        gameValues.volume = value;
    }
}
