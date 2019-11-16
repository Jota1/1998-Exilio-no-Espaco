using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public GameObject[] slots;

    void Update()
    {
        FeedbackInventario();
    }

    void FeedbackInventario()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (itemList[i].showInInventory)
            {
                // Revela todos os slots
                slots[i].GetComponentInChildren<Text>().text = itemList[i].nameItem;
                slots[i].SetActive(true);
            }
        }
    }

    // Verifica se tem o item no inventário
    public bool CheckCondition(string condition)
    {
        // Variable Local
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
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponentInChildren<Text>().text = "";
            slots[i].SetActive(false);
        }

        itemList.Clear();
    }

}
