using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDoor : MonoBehaviour
{
    public bool isOpen;
    public GameObject obj;

    void ControlDoor()
    {
        obj.SetActive(isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ControlDoor();
        }
    }
}
