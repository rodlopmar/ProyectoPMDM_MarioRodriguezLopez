
using UnityEngine;

public class PlataformaVerticalRotatoria : MonoBehaviour
{
    [SerializeField]
    float velocidad = 2f;

    [SerializeField]
    float distancia = 3f;

    float posicionInicial;
    float direccion = 1;

    void Start()
    {
        posicionInicial = transform.position.y;
    }

    void Update()
    {
        transform.position += new Vector3(0, direccion * velocidad * Time.deltaTime, 0);

        if (transform.position.y >= posicionInicial + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.y <= posicionInicial - distancia)
        {
            direccion = 1;
        }
    }
}
