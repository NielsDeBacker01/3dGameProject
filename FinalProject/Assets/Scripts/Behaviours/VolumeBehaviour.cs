using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public GameValues gameValues;
    public float multiplier = 1;
    // Update is called once per frame
    void Update()
    {
        this.music.volume = gameValues.volume * multiplier;
    }
}
