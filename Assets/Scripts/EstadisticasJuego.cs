
using UnityEngine;
using TMPro;

public class EstadisticasJuego : MonoBehaviour
{
    public TextMeshProUGUI textoFrutas;
    public TextMeshProUGUI textoVidas;

    int contador = 0;
    public int vidas = 3;

    void Start()
    {
        textoFrutas.text = "0";
        ActualizarVidas();
    }

    public void SumarFruta()
    {
        contador++;
        textoFrutas.text = "" + contador;
    }

    public void RestarVida()
    {
        vidas--;
        ActualizarVidas();
    }

    void ActualizarVidas()
    {
        textoVidas.text = "" + vidas;
    }
}
