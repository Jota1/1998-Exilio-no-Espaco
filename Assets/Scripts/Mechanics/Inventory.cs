using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool isEmpty;

    public Transform objHold;

    public void CatchItem(Vector3 obj)
    {
        isEmpty = true;
        objHold.position = obj;
    }

}
