using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killed : MonoBehaviour
{
    public AudioClip deathSound;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Instantiate(particle, transform.position, transform.rotation);
            if (deathSound)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(deathSound);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(deathSound, transform.position);
                }
            }
            GameObject.Find("Player").GetComponent<Shoot>().GetAmmo();
            GameObject.Find("SpawnPoints").GetComponent<SpawnScript>().enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
