using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public bool CheckCondition(string condition)
    {
        for(int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].nameItem == condition)
                return true;                
            else
                return false;  
        }
    }

}
