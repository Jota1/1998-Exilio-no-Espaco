using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderCommands : MonoBehaviour
{
    public GameObject menuCommand;    
    bool isOpen;
    public static bool comandMenu_Open;
  
    void Start()
    {
        menuCommand.SetActive(false);
        isOpen = true;
    }

    void Update()
    {
        ControlCommand();
    }

    void ControlCommand() //colocar no botao a função on mouse over (colocar tag no botao e comparar a tag quando soltar o botao em cima dele )
    {
        if (Input.GetKey(KeyCode.Space))
        {
            menuCommand.SetActive(true);
            comandMenu_Open = true;
        }
        else
        {
            CloseMenu();
            comandMenu_Open = false;
        }      
    }

    void CloseMenu()
    {
        menuCommand.SetActive(false);
        isOpen = false;
    }
}
