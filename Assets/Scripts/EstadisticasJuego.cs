
using UnityEngine;
using TMPro;

public class EstadisticasJuego : MonoBehaviour
{
    public TextMeshProUGUI textoFrutas;
    int contador = 0;

    void Start()
    {
        textoFrutas.text = "0";
    }

    public void SumarFruta()
    {
        contador++;
        textoFrutas.text = "" + contador;
    }
}
