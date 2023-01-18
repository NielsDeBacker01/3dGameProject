using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 20;
    private int points;
    private int pointsNeeded = 500;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = $"Current health: {health}/20 \n Enemies defeated: {points}/{pointsNeeded}";
        if (health<=0)
        {
            // ded moomers
        }
        if (points>=pointsNeeded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 50,ForceMode.Force);
            // moomers go zoomers
        }
    }
    public void TakeDamage()
    {
        health--;
    }
    public void UpdatePoint()
    {
        points++;
    }
}
