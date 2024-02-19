using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float distance;
    public float amount;
    public float movement;
    public GameObject fire;
    public Transform firePoint;
    public Vector2 facingDirection = Vector2.left;

    private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MoveObject");
        deathSound = GetComponent<AudioSource>();
    }


    IEnumerator MoveObject()
    {
        while (true)
        {
            transform.Translate(new Vector2(0, distance * movement));
            amount--;
            if (amount <= 0)
            {
                movement = movement * -1;
                amount = 5;
                Instantiate(fire, firePoint.position, facingDirection == Vector2.right ? Quaternion.Euler(0, 180, 0) : firePoint.rotation);
            }
            yield return new WaitForSeconds(.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            deathSound.Play();
            Invoke("Die", .4f);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
