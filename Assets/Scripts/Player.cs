using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { floating, grounded };

public class Player : MonoBehaviour

    //FAZER: movimentaçao na gravidade zero ir pra direção que o jogador esta indo    
{
    public States state; //estados do jogador    
    Rigidbody rb;

    [Header("Animations")]
    [SerializeField]
    Animator playerAnimator;

    [Header("Values")]
    public float speed; //velocidade do player
    public float gravity; //gravidade
    public float turnSpeed; //velocidade que o jogador gira
    public float gravityForce; //impacto da gravidade quando desligada   
    public float torqueForcer; //força do torque no jogador quando ele esta se movimentando em gravidade zero
    public float turnSpeedZeroG; //velocidade que o jogador vira na gravidade zero    

    [Header("Start Game")]
    [SerializeField]
    GameObject blackImage;
    [SerializeField]
    AudioClip fala1_Carol;
    [SerializeField]
    AudioClip fala1_Hal; 
    [SerializeField]
    AudioSource ECG; //EletroCardioGrama
    bool doneSpeak;
    bool doneSpeak2;

    [Header("Audio")]
    SoundController sound_controller;
    public AudioSource playerAudio;
 
    float mass = 5.0F; //massa do jogador
    Vector3 impact = Vector3.zero; //Impacto ao desligar gravidade
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {        
        rb = GetComponent<Rigidbody>();
        state = States.grounded;
        //inicio cinematic
        blackImage.SetActive(true);
        ECG.Play();
    }

    void Update()
    {
        StartCoroutine(StartGame());            

        ChangeStates();     
    }

    private void FixedUpdate()
    {
        //atualizando fisica com base na gravidade / estados do jogador
        if (state == States.grounded)
            BasicMovement();
        else if(state == States.floating)
        {
            ZeroGravityMovement();
        }              
    }

    #region Movimentação Jogador
    //movimentação basica do jogador 
    void BasicMovement()
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed, 0);

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.S))
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
   

    }   

    //movimentação na gravidade zero
    void ZeroGravityMovement ()
    {
        //cima baixo movimento
        if (Input.GetKey(KeyCode.LeftShift) && state == States.floating)
        {
            rb.AddForce(Vector3.up * torqueForcer, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.LeftControl) && state == States.floating)
        {
            rb.AddForce(Vector3.down * torqueForcer, ForceMode.Impulse);
        }

        //frente tras movimento
        if (Input.GetKey(KeyCode.W) && state == States.floating)
        {            
            rb.AddForce(transform.TransformDirection(Vector3.forward) * torqueForcer, ForceMode.Impulse);            
        }
        else if (Input.GetKey(KeyCode.S) && state == States.floating)
        {
            rb.AddForce(transform.TransformDirection(Vector3.back) * torqueForcer, ForceMode.Impulse);
        }
       
        //rotação movimento 
        if (Input.GetKey(KeyCode.A) && state == States.floating)
        {
            rb.AddTorque(Vector3.down * turnSpeedZeroG, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.D) && state == States.floating)
        {
            rb.AddTorque(Vector3.up * turnSpeedZeroG, ForceMode.Impulse);
        }
    }
    #endregion

    //add esse void ao botão que vai executar a função
    public void Command_Zero_Gravity ()
    {
        StartCoroutine(ZeroGravity());
    }
    //add esse void ao botão que vai executar a função
    public void Command_Back_Gravity ()
    {
        StartCoroutine(Back_Gravity());
    }

    //mudança de estados do jogador (flutuando / no chão)
    void ChangeStates()
    {
        if (state == States.floating && state != States.grounded)
        {
            playerAnimator.SetBool("Float", true);
            playerAnimator.SetFloat("Speed", 0);

            ZeroGravityMovement();
        }
        else if (state == States.grounded && state != States.floating)
        {
            playerAnimator.SetBool("Float", false);
        }
    }

    //calculo de add force ao jogador (inicio da gravidade zero)
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();

        if (dir.y < 0)        
            dir.y = -dir.y;
        
        impact += dir.normalized * force / mass;
    }

    #region IEnumerators
    //Cinematic Inicio do jogo
    IEnumerator StartGame ()
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

        if (doneSpeak2 == false)
        {
            playerAudio.PlayOneShot(fala1_Hal);
            doneSpeak2 = true;
        }
    }

    //mecanica de gravidade zero 
    IEnumerator ZeroGravity()
    {
        state = States.floating;
        rb.useGravity = false;
        gravity = -0.0001f;
        yield return new WaitForSeconds(0.5f);
        AddImpact(Vector3.up, gravityForce);
    }

    //gravidade volta ao normal
    IEnumerator Back_Gravity()
    {
        AddImpact(Vector3.down, gravityForce);
        yield return new WaitForSeconds(0.8f);
        state = States.grounded;
        rb.useGravity = true;
        gravity = 9.8f;
    }
    #endregion
}
