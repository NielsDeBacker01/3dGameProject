using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject target;
    float damageDist=2;
    float attackCooldown = 2;
    float timer=10;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        agent.SetDestination(target.transform.position);
        if (Vector3.Distance(transform.position,target.transform.position)<=damageDist&&timer>attackCooldown)
        {
            target.GetComponentInParent<Player>().TakeDamage();
            timer = 0;
        }
    }

}