using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UseItem(string item, string rightItem)
    {
        if(item == rightItem)
        {
            Debug.Log("Utiliza o item");
        }
    }

    public void Voltimeter()
    {
        Debug.Log("Utiliza o voltimetro");
    }

    public void Interact()
    {
        Debug.Log("Interage com o objeto");
    }


}
