
using UnityEngine;
using UnityEngine.SceneManagement;

public class TuboTeletransporte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("PosicionX", -8.62f);
            PlayerPrefs.SetFloat("PosicionY", 4.74f);

            SceneManager.LoadScene("Subnivel");
        }
    }
}
