using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

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

    public void Interact()
    {
        Debug.Log("Interage com o objeto");
    }


}
