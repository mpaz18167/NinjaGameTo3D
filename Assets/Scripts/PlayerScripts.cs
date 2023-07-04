using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScripts : MonoBehaviour
{

    public float playerSpeed;

    public float playerRotation;

    public float fuerzaSalto=8f ;

    public bool playerMove=false;
    public bool puedoSaltar;

    public bool atacando;
    

    
    private Animator playerAnim;

    private Rigidbody rb;


    private Vector3 displacement; //desplazamiento




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        puedoSaltar = false;

    }

    void FixedUpdate()
    {
        float movh = Input.GetAxis("Horizontal");
        
        PlayerMove(movh);

        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !atacando)
        {
            playerAnim.SetTrigger("Shuriken");

        }


    }
    void Update()
    {
        Saltar();
        
    }

    void PlayerMove(float movh)
    {
        displacement.Set(0f,0f,movh);
        displacement= displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + displacement);
        
        if(movh != 0f)
        {
            PlayerRotate(movh);
        }

        bool playerRun = movh != 0f;
        if(playerRun)
        {
            playerMove = true;
        }
        else
        {
            playerMove = false;
        }

        playerAnim.SetFloat("VelZ", movh);
    }



    void PlayerRotate(float movh)
    {
        float interpolation = playerRotation * Time.deltaTime;
        Vector3 targetDirection = new Vector3(0f,0f,movh);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, interpolation);
        rb.MoveRotation(newRotation);
    }

    void Saltar()
    {
        if(puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                playerAnim.SetBool("Salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                
            }
            playerAnim.SetBool("tocoSuelo", true);

        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        playerAnim.SetBool("tocoSuelo", false);
        playerAnim.SetBool("Salte", false);
    }


    public void DejoAtacar()
    {
        atacando = false;
    }
}
        
