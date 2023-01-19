using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 10;
    private int points;
    private int pointsNeeded = 500;
    public TextMeshProUGUI text;
    public LevelEvent levelEvent;
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
            levelEvent.gameOver();
        }
        if (points>=pointsNeeded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 50,ForceMode.Force);
            if(gameObject.transform.position.y >= 200)
            {
                levelEvent.loadNextLevel();
            }
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
