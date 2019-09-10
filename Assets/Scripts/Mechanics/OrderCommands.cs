using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderCommands : MonoBehaviour
{
    public GameObject menuCommand;
    public Text dialogue_Text;
    bool isOpen;
    public static bool comandMenu_Open;
    [SerializeField]
    Animator dialogueBox;
    [SerializeField]
    GameObject command_AbrirPorta;
    [SerializeField]
    GameObject command_LigarEnergia;
    [SerializeField]
    GameObject command_Dica;
    [SerializeField]
    GameObject command_DesligueEnergia; 

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

        //if (Input.GetMouseButton(1) && isOpen){

        //    menuCommand.SetActive(true);

        //} else if(Input.GetMouseButton(1) && !isOpen)
        //{
        //    CloseMenu();
        //}
    }    

    void CloseMenu()
    {
        menuCommand.SetActive(false);
        isOpen = false;
    }

    public void Command1()
    {
        Debug.Log("Abra a porta");
        dialogueBox.SetBool("Open", true);
        dialogue_Text.text = "";
        dialogue_Text.text = "Abrindo a porta";

        command_AbrirPorta.SetActive(true);
        command_LigarEnergia.SetActive(false);
        command_DesligueEnergia.SetActive(false);
        command_Dica.SetActive(false);

        //StartCoroutine(Dialogue_Text_AbrirPorta());

        Invoke("CloseDialogue", 1.8f);
        CloseMenu();
    }

    IEnumerator Dialogue_Text_AbrirPorta () 
    {
        dialogueBox.SetBool("Open", true);
        yield return new WaitForSeconds(0.5f);
        dialogue_Text.text = "";
        yield return new WaitForSeconds(0.5f);
        dialogue_Text.text = "Abrindo a porta";
    }

    public void Command2()
    {
        Debug.Log("Liga a energia");
        dialogueBox.SetBool("Open", true);

        command_AbrirPorta.SetActive(false);
        command_LigarEnergia.SetActive(true);
        command_DesligueEnergia.SetActive(false);
        command_Dica.SetActive(false);

        Invoke("CloseDialogue", 1.8f);
        CloseMenu();
    }

    public void Command3()
    {
        Debug.Log("Desliga a energia");
        dialogueBox.SetBool("Open", true);

        command_AbrirPorta.SetActive(false);
        command_LigarEnergia.SetActive(false);
        command_DesligueEnergia.SetActive(true);
        command_Dica.SetActive(false);

        Invoke("CloseDialogue", 1.8f);
        CloseMenu();
    }

    public void Command4()
    {
        Debug.Log("Dica");
        dialogueBox.SetBool("Open", true);

        command_AbrirPorta.SetActive(false);
        command_LigarEnergia.SetActive(false);
        command_DesligueEnergia.SetActive(false);
        command_Dica.SetActive(true);

        Invoke("CloseDialogue", 1.8f);
        CloseMenu();
    }

    void CloseDialogue ()
    {
        dialogueBox.SetBool("Open", false);
    }

}
