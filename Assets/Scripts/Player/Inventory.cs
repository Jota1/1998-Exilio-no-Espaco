using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    // Verifica se tem o item no inventário
    public bool CheckCondition(string condition)
    {
        string item = "";
        
        for(int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].nameItem == condition)
                item = condition;
        }

        return item == condition;
    }

    public  void ClearList()
    {
        itemList.Clear();
    }

}
