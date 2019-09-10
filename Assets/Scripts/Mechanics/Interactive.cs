using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour, IInteract
{

    public bool canUse { get; set; }

    public GameObject voltimeterObj;

    public void UseItem(string item, string rightItem)
    {
        if(item == rightItem)
        {
            Debug.Log("Utiliza o item");
        }
    }

    public void Voltimeter()
    {
        voltimeterObj.SetActive(true);
    }

    public void Interaction()
    {

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
