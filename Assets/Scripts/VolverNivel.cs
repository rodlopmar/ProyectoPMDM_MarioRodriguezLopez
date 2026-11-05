using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("VolverX", 81.75f);
            PlayerPrefs.SetFloat("VolverY", -2.27f);

            PlayerPrefs.SetInt("VolverDesdeSubnivel", 1);

            SceneManager.LoadScene("Nivel1");
        }
    }
}