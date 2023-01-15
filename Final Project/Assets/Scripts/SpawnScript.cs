using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    List<Spawn> spawnPoints;
    public List<GameObject> enemies;
    public TextMeshProUGUI enemyNr;
    public GameObject enemy;
    float timer;
    int count = 0;
    // Start is called before the first frame update
    void Awake()
    {
        spawnPoints = new List<Spawn>();
        enemies = new List<GameObject>();

        spawnPoints.AddRange(GetComponentsInChildren<Spawn>());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 10/*&&enemies.Count<=150*/)
        {
            timer = 0;
            if(count<=5)
            count++;
            for (int i = 0; i < count*10; i++)
            {
                Spawn();
            }
        }
        enemyNr.text = $"Enemies: {enemies.Count}";
    }
    public void Spawn()
    {
        int index = Random.Range(0, 50);
        Spawn newSpawn = spawnPoints[index];
        GameObject trash=Instantiate(enemy, transform.position, transform.rotation);
        enemies.Add(trash);
        trash.transform.parent = GameObject.Find("Terrain").transform;
        trash.transform.position = newSpawn.transform.position;
    }
}
