using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public Transform handPlayer;

    public bool canUse { get; set; }

    public void Interaction()
    {
        if (canUse)
        {
            transform.position = handPlayer.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canUse = false;
        }
    }

}
