using System;
using UnityEngine;
using TMPro;

public class AnimacionPiña : MonoBehaviour
{

    int estado = 0;
    Animator animacion;
    EstadisticasJuego estadisticas;
    AudioSource sonido;
    [SerializeField]
    AudioClip sonidoFruta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animacion = GetComponent<Animator>();
        estadisticas = FindFirstObjectByType<EstadisticasJuego>();
        sonido = GetComponent<AudioSource>();
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
            sonido.PlayOneShot(sonidoFruta);
            estadisticas.SumarFruta();
        }
    }

    void destruirObjeto()
    {
        Destroy(gameObject);   
    }

}
