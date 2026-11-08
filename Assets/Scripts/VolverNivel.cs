using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverNivel : MonoBehaviour
{
    AudioSource sonido;
    [SerializeField]
    AudioClip sonidoTuberia;

    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sonido.PlayOneShot(sonidoTuberia);

            PlayerPrefs.SetFloat("VolverX", 81.75f);
            PlayerPrefs.SetFloat("VolverY", -2.27f);

            PlayerPrefs.SetInt("VolverDesdeSubnivel", 1);

            Invoke("CambiarEscena", sonidoTuberia.length);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("Nivel1");
    }
}