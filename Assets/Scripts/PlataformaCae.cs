
using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float tiempoCaida = 0.5f;

    bool activada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activada)
        {
            activada = true;
            Invoke("Caer", tiempoCaida);
        }
    }

    void Caer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
