
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
        if (PlayerPrefs.HasKey("Vidas"))
        {
            vidas = PlayerPrefs.GetInt("Vidas");
        }
        else
        {
            PlayerPrefs.SetInt("Vidas", vidas);
        }

        if (PlayerPrefs.HasKey("Frutas"))
        {
            contador = PlayerPrefs.GetInt("Frutas");
        }
        else
        {
            PlayerPrefs.SetInt("Frutas", contador);
        }

        textoFrutas.text = "" + contador;
        ActualizarVidas();
    }

    public void SumarFruta()
    {
        contador++;

        PlayerPrefs.SetInt("Frutas", contador);

        textoFrutas.text = "" + contador;
    }

    public void RestarVida()
    {
        vidas--;
        PlayerPrefs.SetInt("Vidas", vidas);
        ActualizarVidas();
    }

    void ActualizarVidas()
    {
        textoVidas.text = "" + vidas;
    }
}
