using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LogicaObjetivosEsferas : MonoBehaviour
{
    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMision;

    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length;
        textoMision.text = "Recupera todos los orbes"+
                           "\n Restantes: " + numDeObjetivos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numDeObjetivos --;
            textoMision.text= "Recupera todos los orbes" +
                              "\n Restantes: " + numDeObjetivos;
            if(numDeObjetivos <=0)
            {
                textoMision.text = "Bien Hecho" + 
                    "\n Sigue al otro nivel";
                botonDeMision.SetActive(true);
            }
        }
    }
}
