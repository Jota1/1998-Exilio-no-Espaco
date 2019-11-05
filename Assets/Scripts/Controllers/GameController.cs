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
    AudioClip fala1_Hal;
    [SerializeField]
    AudioSource ECG; //EletroCardioGrama
    bool doneSpeak;
    bool doneSpeak2;
    public static bool doneSpeak3;

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
        yield return new WaitForSeconds(7f);
        if (doneSpeak == false)
        {
            playerAudio.PlayOneShot(fala1_Carol);
            doneSpeak = true;
        }

        yield return new WaitForSeconds(6f);
        ECG.Stop();
        blackImage.SetActive(false);
        firstDialogueTuto = true;
        
        if (doneSpeak2 == false)
        {
            playerAudio.PlayOneShot(fala1_Hal);
            doneSpeak2 = true;
        }

        yield return new WaitForSeconds(9f);

        if (doneSpeak3 == false)
        {
            playerAudio.PlayOneShot(fala2_Carol);
            doneSpeak3 = true;
        }
    }
}
