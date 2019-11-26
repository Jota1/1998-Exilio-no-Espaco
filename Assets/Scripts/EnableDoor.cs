using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDoor : MonoBehaviour
{
    public bool isOpen;
    public GameObject obj;

    public bool door1;
    public bool door2;

    void ControlDoor()
    {
        obj.SetActive(isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ControlDoor();

            if (door1)
                FindObjectOfType<AIController>().EnableTimer();

            if (door2)
                FindObjectOfType<AIController>().EnableTimer();

        }
    }
}
