
using UnityEngine;
using UnityEngine.SceneManagement;

public class TuboTeletransporte : MonoBehaviour
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

            PlayerPrefs.SetFloat("PosicionX", -8.62f);
            PlayerPrefs.SetFloat("PosicionY", 4.74f);

            Invoke("CambiarEscena", sonidoTuberia.length);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("Subnivel");
    }
}
