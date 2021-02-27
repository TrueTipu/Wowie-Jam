using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool movable = true;
    float tileLength = 1;

    public float waitTime;
    float waitTimer;

    public LayerMask interactable;

    public int serialNumber;
    // Update is called once per frame
    void Update()
    {
        if(movable)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 )
            {
                Move(Mathf.Round(Input.GetAxisRaw("Horizontal")), true);
            }
            else if(Input.GetAxisRaw("Vertical") != 0)
            {
                Move(Mathf.Round(Input.GetAxisRaw("Vertical")), false);
            }
        }
        else
        {
            TileTimer();
        }
    }

    void Move(float dir, bool x)
    {
        movable = false;
        waitTimer = waitTime;
        if(x)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir * Vector2.right, 1 , interactable);
            
            if ((hit.collider == null) /*|| (hit.transform.tag != "Wall")*/)
            {
                Debug.Log("HEi");           
                transform.position += new Vector3(dir * tileLength, 0, 0);
            }

        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir * Vector2.up, 1.5f, interactable);
            if ((hit.collider == null) /*|| (hit.transform.tag != "Wall")*/)
            {
                Debug.Log("HEi");
                transform.position += new Vector3(0, dir * tileLength, 0);
            }
        }
    }
    void TileTimer()
    {
        waitTimer -= Time.deltaTime;
        if(waitTimer < 0)
        {
            movable = true;
        }
    }
}
