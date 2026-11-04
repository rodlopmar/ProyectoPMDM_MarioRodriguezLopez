
using UnityEngine;

public class ObjetoEnMovimiento : MonoBehaviour
{
    [SerializeField]
    float velocidad = 1f;

    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime, 0, 0);

        if (transform.position.x >= 49 && velocidad > 0)
        {
            velocidad *= -1;
        }
        else if (transform.position.x <= 44 && velocidad < 0)
        {
            velocidad *= -1;
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
