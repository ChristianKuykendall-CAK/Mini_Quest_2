using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private int direction = 5;
    private Movement playerScript;
    private bool isPlayerDead = false;

    public Vector2 facingDirection = Vector2.left;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Movement>();
        InvokeRepeating("DeathCheck", 1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPlayerDead) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 2f, 0) , Vector2.down, 2f);
            Debug.Log(hit.collider);
            Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

            if (hit.collider == null)
            {
                direction = direction * -1;
                FlipX();
                if (facingDirection == Vector2.left)
                    facingDirection = Vector2.right;
                else
                    facingDirection = Vector2.left;
            }

            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);
        }
    }
    void FlipX()
        {
            Vector3 theScale = transform.localScale;
            theScale.x = theScale.x * -1;
            transform.localScale = theScale;
        }

    public void DeathCheck()
    {
        isPlayerDead = playerScript.isPlayerDead();
    }
}
