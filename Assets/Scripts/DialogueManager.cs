using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogue_Text;
    public string[] setences;
    private int index;
    public float typingSpeed;
    public Animator dialogueText_Animator;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type ()
    {
        foreach (char letter in setences[index].ToCharArray())
        {
            dialogue_Text.text += letter;
            yield return new WaitForSeconds(typingSpeed);           
        }        
    }

    private void Update()
    {
        //TESTE
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(AnimationControl_DialogueBox());
        }            
    }

    IEnumerator AnimationControl_DialogueBox () //colocar ESTE Ienumerator para mostrar a próxima sentença (definir dialogos de forma linear)
    {
        dialogueText_Animator.SetTrigger("Open");   //obs: colocar a primeira sentença como vazia (sem nenhuma palavra)
        yield return new WaitForSeconds(0.7f);
        NextSentence();
        yield return new WaitForSeconds(3f);
        dialogueText_Animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.5f);
        dialogue_Text.text = "";
    }

    public void NextSentence () 
    {
        if (index < setences.Length - 1)
        {
            index++;
            dialogue_Text.text = "";
            StartCoroutine(Type());

        }
        else
        {
            dialogue_Text.text = "";
        }
    }    
}

