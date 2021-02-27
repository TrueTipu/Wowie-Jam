using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Transform player;
    int dir;
    int x;
    int y;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("2");
            player = other.transform.parent;
            if (player == null)
            {
                Debug.Log("Joo");
            }
            else if (player.GetComponent<PlayerMovement>().currentParts > 1)
            {


                if ((player.GetComponent<PlayerMovement>().oldPos.y - player.transform.position.y) < 0)
                {
                    dir = 1;
                    y = 1;
                    x = 0;
                }
                else if ((player.GetComponent<PlayerMovement>().oldPos.y - player.transform.position.y) > 0)
                {
                    dir = -1;
                    y = 1;
                    x = 0;
                }
                else if ((player.GetComponent<PlayerMovement>().oldPos.x - player.transform.position.x) < 0)
                {
                    dir = 1;
                    y = 0;
                    x = 1;
                }
                else if ((player.GetComponent<PlayerMovement>().oldPos.x - player.transform.position.x) > 0)
                {
                    dir = -1;
                    y = 0;
                    x = 1;
                }

                transform.position += new Vector3(dir * x, dir * y, 0);
            }
            else
            {
                player.position = player.GetComponent<PlayerMovement>().oldPos;
            }
        }
    }
}
