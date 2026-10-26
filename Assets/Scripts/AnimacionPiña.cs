using System;
using UnityEngine;
using TMPro;

public class AnimacionPiña : MonoBehaviour
{

    int estado = 0;
    Animator animacion;
    EstadisticasJuego estadisticas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animacion = GetComponent<Animator>();
        estadisticas = FindFirstObjectByType<EstadisticasJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        animacion.SetInteger("estado", estado);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estado = 1;
            estadisticas.SumarFruta();
        }
    }

    void destruirObjeto()
    {
        Destroy(gameObject);   
    }

}
