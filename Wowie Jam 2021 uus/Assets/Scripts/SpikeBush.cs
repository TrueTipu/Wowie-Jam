using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBush : MonoBehaviour
{
    PlayerMovement player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("2");
            player = other.transform.GetComponent<PlayerMovement>();
            if (player.serialNumber == 0)
            {
                player.transform.parent.GetComponent<PartCount>().parts[1].enabled = true;
            }
            else
            {
                player.transform.parent.GetComponent<PartCount>().parts[0].enabled = true;
            }
            player.transform.SetParent(null);
        }
    }
}
