
using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float tiempoCaida = 0.5f;

    Vector3 posicionInicial;
    bool activada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
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

    public void ReiniciarPlataforma()
    {
        CancelInvoke("Caer");

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = posicionInicial;

        activada = false;
    }
}
