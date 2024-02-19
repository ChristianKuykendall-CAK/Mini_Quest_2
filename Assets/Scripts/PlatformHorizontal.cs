using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{
    public float distance;
    public float amount;
    public float movement;
    void Start()
    {
        StartCoroutine("MovePlatform");
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            transform.Translate(new Vector2(distance * movement, 0));
            amount--;
            if (amount <= 0)
            {
                movement = movement * -1;
                amount = 5;
            }
            yield return new WaitForSeconds(.2f);
        }
    }
}
