using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject blast;
    public float cooldown = 2f;
    public int shootForce=10;
    public int ammo=10;
    public int ammoLimit=10;
    float timer = 10f;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float shoot = Input.GetAxis("Fire1");
        if (shoot == 1 && timer >= cooldown&&ammo>0)
        {
            started = true;
            ammo--;
            GameObject trashBlast = Instantiate(blast, transform.position, transform.rotation);
            trashBlast.GetComponent<Rigidbody>().AddForce(shootForce*transform.forward);
            timer = 0;
        }
        if (started)
        {
            if (timer<cooldown)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = cooldown;
                started = false;
            }
        }
    }
    public void GetAmmo()
    {
        if(ammo<ammoLimit)
        ammo++;
    }
}
