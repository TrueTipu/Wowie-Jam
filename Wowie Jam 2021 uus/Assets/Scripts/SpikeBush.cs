using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBush : MonoBehaviour
{
    Transform player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("2");
            player = other.transform.GetComponent<Transform>();
            player.SetParent(null);
            player.gameObject.layer = 8;
        }
    }
}
