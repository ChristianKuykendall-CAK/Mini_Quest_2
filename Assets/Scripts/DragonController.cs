using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Animator anim;
    private AudioSource deathSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            anim.SetBool("isDead", true);
            GetComponent<Patrol>().enabled = false;
            deathSound.Play();
            Invoke("Die", .4f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.health -= 1;
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    } 
}
