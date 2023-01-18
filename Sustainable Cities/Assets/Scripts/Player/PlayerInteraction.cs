using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerInteraction : MonoBehaviour
{
    public GameManager manager;

    [Header("Health")]
    public HealthBar healthBar;
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Watertank")]
    public WaterBar waterTank;
    public int maxWater = 6;
    public int currentWater;

    private GameObject[] objects;
    private int counter;
    private bool change = false;
    private bool isHit;

    private void Start()
    {
        currentWater = 0;
        currentHealth = maxHealth;
        counter = 0;
        waterTank.SetMaxWater(maxWater);
        healthBar.SetMaxHealth(maxHealth);
        objects = GameObject.FindGameObjectsWithTag("Change");
    }

    private void Update()
    {
        if (objects[4].GetComponent<MeshRenderer>().enabled == true) 
            manager.CompleteLevel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Well")
        {
            currentWater++;
            waterTank.SetWater(currentWater);
        }

        if (collision.collider.tag == "Tree" && currentWater > 0)
        {
            currentWater--;
            waterTank.SetWater(currentWater);


            if (counter < 4)
                counter++;
            else
                change = true;

            if (change == false)
            {
                objects[counter].GetComponent<MeshRenderer>().enabled = false;
                objects[counter + 1].GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (collision.collider.tag == "Obstacle" && isHit == false)
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            isHit = true;

            Invoke(nameof(ResetHit), 2);
        }
    }

    private void ResetHit()
    {
        isHit = false;
    }
}
