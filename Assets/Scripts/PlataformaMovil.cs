
using UnityEngine;

public class ObjetoEnMovimiento : MonoBehaviour
{
    [SerializeField]
    float velocidad = 1f;

    [SerializeField]
    float distancia = 3f;

    float posicionInicial;
    float direccion = 1;

    void Start()
    {
        posicionInicial = transform.position.x;
    }

    void Update()
    {
        transform.position += new Vector3(direccion * velocidad * Time.deltaTime, 0, 0);

        if (transform.position.x >= posicionInicial + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.x <= posicionInicial - distancia)
        {
            direccion = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
