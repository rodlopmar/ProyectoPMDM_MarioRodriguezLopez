using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public void VolverAJugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
    }
}