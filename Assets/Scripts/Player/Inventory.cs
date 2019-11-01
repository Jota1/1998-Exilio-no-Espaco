﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public bool CheckCondition(string condition)
    {
        string item = "";
        
        for(int i = 0; i < itemList.Count; i++)
        {
            if (item == condition)
                item = condition;
        }

        return item == condition;
    }

}
