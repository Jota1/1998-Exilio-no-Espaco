using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    int wasdCounter; //contando o tempo que o jogador ficou andando
    public static bool tutoMovFinalizado;
    public static bool tutoGrvtFinalizado; 

    bool firstGravityOn; //identificando a primeira vez q ligou a gravidade 

    [Header("Dialogos Tutorial")] 
    public Text dialogo_TXT_Tutorial;
    //public GameObject hal_Icon;

    void Start()
    {
        wasdCounter = 0;
        dialogo_TXT_Tutorial.text = "Use WASD para se movimentar";
    }
    
    void Update()
    {
        TutoMovimentação();
        TutoGravity();

        if (GameController.doneSpeak3 && !tutoGrvtFinalizado)
        {
            DialogueManager.openDialogueBox = true;            
        }
        //else { DialogueManager.openDialogueBox = false; }
    }

    void CloseDialogueBox ()
    {
        DialogueManager.openDialogueBox = false;
    }

    void TutoMovimentação ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            wasdCounter++;
        }

        if (wasdCounter >= 800)
        {
            tutoMovFinalizado = true;
            dialogo_TXT_Tutorial.text = "Segure 'espaço' e clique em 'Desligar Gravidade'";

            Debug.Log("Tuto mov finalizado");
        }
    }

    void TutoGravity()
    {
        if (tutoMovFinalizado)
        {
            if (tutoGrvtFinalizado)
            {
                dialogo_TXT_Tutorial.text = "Utilize SHIFT e CNTRL para se mover no eixo Y";
                Invoke("CloseDialgueBox", 6f);
            }
        }
    }

    void CloseDialgueBox ()
    {
        DialogueManager.openDialogueBox = false;
    }
}
