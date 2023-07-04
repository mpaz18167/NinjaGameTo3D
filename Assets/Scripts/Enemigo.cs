using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_Walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    private void Start()
    {
       ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
       
    }
    private void Update()
    {
        Comportamientos();
    }

    public void Comportamientos()
    {
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0,2);
        }

        switch (rutina)
        {
            case 0:
                ani.SetBool("walk", false);

                break;
            case 1:
                direccion = Random.Range(0,2);
                rutina++;
                break;
            case 2:
                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        transform.Translate(Vector3.right * speed_Walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                        transform.Translate(Vector3.right * speed_Walk * Time.deltaTime);
                        break;

                }
                ani.SetBool("walk", true);
                break;

        }
    }
}
