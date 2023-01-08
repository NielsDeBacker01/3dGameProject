using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class ShootScript : MonoBehaviour
{
    GameObject Bullet;
    public int BulletSpeed;
    public int maxBullets;
    public bool UnlimitedBullets;
    public int currentBullets;
    public TextMeshProUGUI bulletText;
    public bool showBullets;
    // Start is called before the first frame update
    void Start()
    {     
        Bullet = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBullets > maxBullets){
            currentBullets = maxBullets;
        }

        if(bulletText != null)
        {
            if(showBullets)
            {
                bulletText.enabled = true;
                bulletText.text = "Bullets: " + currentBullets.ToString() + " / " + maxBullets.ToString();
            }
            else
            {
                bulletText.enabled = false;
            }
        } 
    }

    public bool Shoot(int angleShift, Vector3 target, string tag){
        if(currentBullets > 0 || UnlimitedBullets)
        {
            GameObject bullet = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        
            bullet.GetComponent<ShootMovement>().Speed = this.BulletSpeed;
            //aim
            bullet.transform.LookAt(target);

            //apply rotation for split bullet
            bullet.transform.Rotate(0, angleShift, 0);

            //apply tag
            bullet.tag = tag;

            //update bullets
            currentBullets -= 1;

            return true;
        }
        else
        {
            return false;
        }

    }
}