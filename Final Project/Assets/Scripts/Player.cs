using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int Health = 20;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = $"Current health: {Health}/20";
        if (Health<=0)
        {

        }
    }
    public void TakeDamage()
    {
        Health--;
    }
}
