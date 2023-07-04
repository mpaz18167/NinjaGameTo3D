using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarLvl(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    
    public void Nivel3(string nombre)
    {

    }
}
