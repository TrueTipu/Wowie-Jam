using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool movable = true;
    public float tileLength;

    public float waitTime;
    float waitTimer;


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
            transform.position += new Vector3(dir*tileLength, 0, 0);
        }
        else
        {
            transform.position += new Vector3(0, dir*tileLength, 0);
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
