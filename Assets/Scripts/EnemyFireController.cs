using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFireController : MonoBehaviour
{
    private int speed = 15;
    private Vector2 direction = Vector2.right;
    void Start()
    {
        Invoke("Die", 2f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    void Die()
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.health -= 1;
        }
    }
}
