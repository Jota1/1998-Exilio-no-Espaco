﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { floating, grounded };

public class Player : MonoBehaviour

    //FAZER: movimentaçao na gravidade zero ir pra direção que o jogador esta indo    
{
    public States state; //estados do jogador    
    Rigidbody rb;

    public Transform cam;

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
    public float m_MovementSmoothing; // Suavização da velocidade
    private Vector3 m_Velocity = Vector3.zero; // Valor de referência pra movimentação

    [Header("TP")] //temporario 
    public Transform checkPoint_SalaP2;
    public Transform checkpoint_SalaGravidade;

    float mass = 5.0F; //massa do jogador
    Vector3 impact = Vector3.zero; //Impacto ao desligar gravidade
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {        
        rb = GetComponent<Rigidbody>();
        state = States.grounded;            
    }

    void Update()
    {       
        ChangeStates();     
    }

    void FixedUpdate()
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
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveDirection.magnitude));

        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        if (moveDirection.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(camF * moveDirection.y + camR * moveDirection.x);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
        }

        transform.position += (camF * moveDirection.y + camR * moveDirection.x) * Time.deltaTime * speed;
    }   

    //movimentação na gravidade zero
    void ZeroGravityMovement ()
    {

        //cima baixo movimento
        if (Input.GetKey(KeyCode.LeftShift) && state == States.floating)
        {
            Vector3 targetVelocity = new Vector3(rb.velocity.x, speed * Time.deltaTime, rb.velocity.z);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        else if (Input.GetKey(KeyCode.LeftControl) && state == States.floating)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.down * torqueForcer, ForceMode.Impulse);
        }

        //frente tras movimento
        if (Input.GetKey(KeyCode.W) && state == States.floating)
        {
            Vector3 targetVelocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Time.deltaTime);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        else if (Input.GetKey(KeyCode.S) && state == States.floating)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.TransformDirection(Vector3.back) * torqueForcer, ForceMode.Impulse);
        }
       
        //rotação movimento 
        if (Input.GetKey(KeyCode.A) && state == States.floating)
        {
            rb.velocity = Vector3.zero;
            rb.AddTorque(Vector3.down * turnSpeedZeroG, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.D) && state == States.floating)
        {
            rb.velocity = Vector3.zero;
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

    #region Colisões
    private void OnTriggerEnter(Collider other)
    {
        GameObject objCol = other.gameObject;

        if (objCol.tag == "PseudoEscada")
        {
            //toca animação subindo escada
            Debug.Log("ESCADA");
        }

        if (objCol.tag == "PseudoPorta")
        {
            transform.position = checkPoint_SalaP2.position;
            transform.rotation = checkPoint_SalaP2.rotation;

            Debug.Log("Porta Para Sala P2");
        }

        if (objCol.tag == "PseudoPortaP2")
        {
            transform.position = checkpoint_SalaGravidade.position;
            transform.rotation = checkpoint_SalaGravidade.rotation;

            Debug.Log("Porta Para Sala Gravidade");
        }
    }

    private void OnTriggerStay(Collider other)
    {                                                                         
        GameObject objCol = other.gameObject;

        if(objCol.tag == "Interagivel")
        {
            if (Input.GetMouseButtonDown(0))
            {
                objCol.GetComponent<IInteract>().Interaction();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
   
    }
    #endregion

    #region IEnumerators
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
