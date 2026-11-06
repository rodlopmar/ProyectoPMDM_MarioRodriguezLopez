
using UnityEngine;

public class PlataformaSalto : MonoBehaviour
{
    Animator animacion;

    [SerializeField]
    float fuerzaSalto = 20f;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D jugador = collision.gameObject.GetComponent<Rigidbody2D>();

            jugador.linearVelocity = new Vector2(jugador.linearVelocity.x, fuerzaSalto);

            animacion.SetBool("activada", true);
        }
    }

    public void TerminarAnimacion()
    {
        animacion.SetBool("activada", false);
    }
}
