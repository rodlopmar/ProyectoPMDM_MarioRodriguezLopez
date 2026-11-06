
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        PlayerPrefs.SetInt("Vidas", 3);
        PlayerPrefs.SetInt("Frutas", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Nivel1");
    }
}
