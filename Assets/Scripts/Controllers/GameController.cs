using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameMenu;

    [Header("Game Events")]
    public static int eventCounter;

    [Header("Cut Scene Start Game")]
    [SerializeField]
    GameObject blackImage;
    [SerializeField]
    AudioClip fala1_Carol;
    [SerializeField]
    AudioClip fala2_Carol;
    [SerializeField]
    AudioClip fala3_Carol; 
    [SerializeField]
    AudioClip fala1_Hal;
    [SerializeField]
    AudioClip fala2_Hal;
    [SerializeField]
    AudioClip fala3_Hal;
    [SerializeField]
    AudioClip fala4_Hal; 
    [SerializeField]
    AudioSource ECG; //EletroCardioGrama

    bool doneSpeak;
    bool doneSpeak2;
    public static bool doneSpeak3;
    bool doneSpeak4;
    bool doneSpeak5;
    bool doneSpeak6;
    bool doneSpeak7; 

    bool firstDialogueTuto; //primeira fala do tutorial

    [Header("Audio")]
    SoundController sound_controller;
    public AudioSource playerAudio;

    void Start()
    {
        gameMenu.SetActive(false);
        eventCounter = 0;

        ECG.Play(); //som do EletroCardioGrama de fundo
        //inicio cinematic
        blackImage.SetActive(true);   
    }

    void Update()
    {
        UpdateMenu();

        StartCoroutine(StartGame());

        //if (firstDialogueTuto)
            //DialogueManager.dialoguecounter = 1;
    }

    void UpdateMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
                gameMenu.SetActive(true);

            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1f;
                gameMenu.SetActive(false);
            }
        }
    }

    //Cinematic Inicio do jogo
    IEnumerator StartGame() // refazer esquema de falas por som atraves do dialogue manager
    {
        yield return new WaitForSeconds(6f);
        if (doneSpeak == false)
        {
            playerAudio.PlayOneShot(fala1_Hal);
            doneSpeak = true;
        }

        yield return new WaitForSeconds(3.5f); 
        if (doneSpeak2 == false)
        {
            playerAudio.PlayOneShot(fala1_Carol);
            doneSpeak2 = true;
        }

        yield return new WaitForSeconds(6.3f);
        ECG.Stop();
        blackImage.SetActive(false);
        firstDialogueTuto = true;
        
        if (doneSpeak3 == false)
        {
            playerAudio.PlayOneShot(fala2_Hal);
            doneSpeak3 = true;
        }

        yield return new WaitForSeconds(6f);

        if (Tutorial.tutoGrvtFinalizado)
        {
            yield return new WaitForSeconds(3f);
            if (doneSpeak4 == false)
            {
                playerAudio.PlayOneShot(fala3_Carol);
                doneSpeak4 = true;
            }

            yield return new WaitForSeconds(7f);

            if (doneSpeak5 == false)
            {
                playerAudio.PlayOneShot(fala3_Hal);
                doneSpeak5 = true;
            }

            yield return new WaitForSeconds(4f);

            if (doneSpeak6 == false)
            {
                playerAudio.PlayOneShot(fala4_Hal);
                doneSpeak6 = true;
            }
        }
    }
}
