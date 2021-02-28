using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]

    public PartCount partCount;


    public Transform destinaatio;
    PlayerMovement player;

    bool ylin;
    bool alin;
    bool keski;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform.parent.GetComponent<PlayerMovement>();
            if (partCount.parts[0] != null && player.partCount.parts[0].parent != null)
            {
                ylin = true;
            }
            else if (partCount.parts[0] == null && player.partCount.parts[0].parent == null)
            {
                ylin = true;
            }
            else
            {
                ylin = false;
            }
            if (partCount.parts[1] != null && player.partCount.parts[1].parent != null)
            {
                keski = true;
            }
            else if (partCount.parts[1] == null && player.partCount.parts[1].parent == null)
            {
                keski = true;
            }
            else
            {
                keski = false;
            }
            if (partCount.parts[2] != null && player.partCount.parts[2].parent != null)
            {
                alin = true;
            }
            else if(partCount.parts[2] == null && player.partCount.parts[2].parent == null)
            {
                alin = true;
            }
            else
            {
                alin = false;
            }
            if(keski && alin && ylin)
            {
                Debug.Log("Oikea määrä");
                Teleporttaa(destinaatio, player.transform);
            }
        }
    }
    void Teleporttaa(Transform target, Transform pelaaja)
    {
        player.transform.position = new Vector3(target.position.x + 1, target.position.y, target.position.z);
    }
}
