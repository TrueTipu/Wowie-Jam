using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Transform player;
    int dir;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("2");
            player = other.transform.parent;
            if ((transform.position.y - player.transform.position.y) < 0)
            {
                dir = -1;
            }
            else
            {
                dir = 1;
            }

            transform.position += new Vector3(0, dir * 1, 0);
        }
    }
}
