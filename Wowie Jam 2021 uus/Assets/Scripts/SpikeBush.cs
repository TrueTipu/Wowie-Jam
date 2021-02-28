using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBush : MonoBehaviour
{
    Transform player;

    public float time;
    float timer;

    private void Start()
    {
        timer = time;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            if (timer <= 0)
            {
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().Play("Kaktus");
                Debug.Log("2");
                player = other.transform.GetComponent<Transform>();
                player.SetParent(null);
                player.gameObject.layer = 8;
                player.tag = "Untagged";
                timer = time;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer = time;
        }
    }
}
