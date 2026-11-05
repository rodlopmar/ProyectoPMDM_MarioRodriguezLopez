using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public void VolverAJugar()
    {
        PlayerPrefs.SetInt("Vidas", 3);
        PlayerPrefs.SetInt("Frutas", 0);

        SceneManager.LoadScene("Nivel1");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
    }
}