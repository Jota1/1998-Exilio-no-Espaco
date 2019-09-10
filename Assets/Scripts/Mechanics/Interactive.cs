using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour, IInteract
{
    public bool canUse { get; set; }
    public bool completePuzzle;

    public void Interaction()
    {
        Debug.Log("Interagiu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
