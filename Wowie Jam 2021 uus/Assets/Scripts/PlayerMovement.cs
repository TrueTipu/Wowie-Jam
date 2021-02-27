using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool movable = true;
    float tileLength = 1;

    public float waitTime;
    float waitTimer;

    public LayerMask interactable;

    public int serialNumber;

    [SerializeField]

    public PartCount partCount;
    public int currentParts;

    public Vector3 oldPos;

    // Update is called once per frame
    void Update()
    {
        currentParts = CountParts(partCount);
        if(movable)
        {
            oldPos = transform.position;
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
        CheckWin();
    }

    void Move(float dir, bool x)
    {
        movable = false;
        waitTimer = waitTime;
        if(x)
        {
            RaycastHit2D hit;
            RaycastHit2D hit2;
            RaycastHit2D hit3;
            if (partCount.parts[0].parent != null)
            {
                Debug.Log("1");
                hit = Physics2D.Raycast((transform.position + new Vector3(0, 1, 0)), dir * Vector2.right, 1, interactable);
            }
            else
            {
                hit = new RaycastHit2D();
            }
            if (partCount.parts[1].parent != null)
            {
                Debug.Log("2");
                hit2 = Physics2D.Raycast((transform.position + new Vector3(0, 0, 0)), dir * Vector2.right, 1, interactable);
            }
            else
            {
                hit2 = new RaycastHit2D();
            }
            if (partCount.parts[2].parent != null)
            {
                Debug.Log("3");
                hit3 = Physics2D.Raycast((transform.position + new Vector3(0, -1, 0)), dir * Vector2.right, 1, interactable);
            }
            else
            {
                hit3 = new RaycastHit2D();
            }

            if ((hit.collider == null) && (hit2.collider == null) && (hit3.collider == null) )
            {
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().Play("Kävely");
                Debug.Log("HEi");           
                transform.position += new Vector3(dir * tileLength, 0, 0);
            }

        }
        else
        {
            RaycastHit2D hit;
            RaycastHit2D hit2;
            RaycastHit2D hit3;
            if (partCount.parts[0].parent != null)
            {
                Debug.Log("1");
                hit = Physics2D.Raycast((transform.position + new Vector3(0, 1, 0)), dir * Vector2.up, 1, interactable);
            }
            else
            {
                hit = new RaycastHit2D();
            }
            if (partCount.parts[1].parent != null)
            {
                Debug.Log("2");
                hit2 = Physics2D.Raycast((transform.position + new Vector3(0, 0, 0)), dir * Vector2.up, 1, interactable);
            }
            else
            {
                hit2 = new RaycastHit2D();
            }
            if (partCount.parts[2].parent != null)
            {
                Debug.Log("3");
                hit3 = Physics2D.Raycast((transform.position + new Vector3(0, -1, 0)), dir * Vector2.up, 1, interactable);
            }
            else
            {
                hit3 = new RaycastHit2D();
            }
            
            if ((hit.collider == null) && (hit2.collider == null) && (hit3.collider == null))
            {
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().Play("Kävely");
                Debug.Log("HEi");
                transform.position += new Vector3(0, dir * tileLength, 0);
            }
        }
    }

    int CountParts(PartCount partsToCount)
    {
        int storage = 0;
        if (partCount.parts[0].parent != null)
        {
            storage += 1;
        }
        if (partCount.parts[1].parent != null)
        {
            storage += 1;
        }
        if (partCount.parts[2].parent != null)
        {
            storage += 1;
        }
        return storage;
    }
    void CheckWin()
    {
        if(currentParts == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
