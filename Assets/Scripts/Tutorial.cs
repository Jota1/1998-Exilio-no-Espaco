using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    int wasdCounter; //contando o tempo que o jogador ficou andando
    bool tutoMovFinalizado;

    bool firstGravityOn; //identificando a primeira vez q ligou a gravidade 

    void Start()
    {
        wasdCounter = 0;        
    }
    
    void Update()
    {
        TutoMovimentação();
        TutoGravity();
    }

    void TutoMovimentação ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            wasdCounter++;
        }

        if (wasdCounter >= 400)
        {
            tutoMovFinalizado = true;
            Debug.Log("Tuto mov finalizado");
        }
    }

    void TutoGravity ()
    {
        if (tutoMovFinalizado)
        {
            //inicia tutorial gravidade 
        }
    }
}
