
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class MovimientoJugador : MonoBehaviour
{
    InputAction movimientoAction;
    InputAction saltarAction;
    Rigidbody2D rb2d;
    BoxCollider2D collider2D;

    [SerializeField]
    float velocidad = 5f;
    [SerializeField]
    float velocidadSalto = 15f;
    int numSaltos = 0;
    [SerializeField]
    float limiteCaida = -10f;

    [SerializeField]
    LayerMask Suelo;

    Animator playerAnimator;
    int estadoAnimacion = 0;
    bool recibiendoDaño = false;
    EstadisticasJuego estadisticas;

    bool muerto = false;

    Vector3 posicionCheckpoint;


    void Start()
    {
        movimientoAction = InputSystem.actions.FindAction("Move");
        saltarAction = InputSystem.actions.FindAction("Jump");

        rb2d = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();

        estadisticas = FindFirstObjectByType<EstadisticasJuego>();

        if (SceneManager.GetActiveScene().name == "Subnivel")
        {
            float x = PlayerPrefs.GetFloat("PosicionX");
            float y = PlayerPrefs.GetFloat("PosicionY");

            transform.position = new Vector3(x, y, transform.position.z);
        }

        posicionCheckpoint = transform.position;
    }


    void Update()
    {
        if (muerto || recibiendoDaño)
        {
            return;
        }
        if (transform.position.y < limiteCaida)
        {
            PerderVidaPorCaida();
            return;
        }

        Moverse();
        Saltar();

        if (rb2d.linearVelocityY > 0.1f)
        {
            if (numSaltos == 2)
            {
                estadoAnimacion = 3;
            }
            else
            {
                estadoAnimacion = 2;
            }
        }
        else if (rb2d.linearVelocityY < -0.1f)
        {
            estadoAnimacion = 5;
        }
        else if (rb2d.linearVelocityX > 0)
        {
            estadoAnimacion = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb2d.linearVelocityX < 0)
        {
            estadoAnimacion = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            estadoAnimacion = 0;
        }

        playerAnimator.SetInteger("estado", estadoAnimacion);
    }

    void Moverse()
    {
        Vector2 movimiento = movimientoAction.ReadValue<Vector2>();
        rb2d.linearVelocityX = movimiento.x * velocidad;
    }

    void Saltar()
    {
        if (saltarAction.WasPressedThisFrame())
        {
            if (EstaTocandoSuelo())
            {
                numSaltos = 0;
                rb2d.linearVelocityY = velocidadSalto;
                numSaltos++;
            }
            else if (numSaltos < 2)
            {
                rb2d.linearVelocityY = velocidadSalto;
                numSaltos++;
            }
        }
    }

    bool EstaTocandoSuelo()
    {
        return Physics2D.BoxCast(
            collider2D.bounds.center,
            collider2D.bounds.size,
            0f,
            Vector2.down,
            .01f,
            Suelo
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos") && !recibiendoDaño && !muerto)
        {
            estadisticas.RestarVida();

            rb2d.linearVelocity = Vector2.zero;

            if (estadisticas.vidas <= 0)
            {
                muerto = true;
                estadoAnimacion = 6;
                playerAnimator.SetInteger("estado", estadoAnimacion);
            }
            else
            {
                recibiendoDaño = true;
                estadoAnimacion = 4;
                playerAnimator.SetInteger("estado", estadoAnimacion);
            }
        }
    }

    public void GuardarCheckpoint(Vector3 posicion)
    {
        posicionCheckpoint = posicion;
    }


    public void TerminarDaño()
    {
        if (muerto)
        {
            return;
        }

        transform.position = posicionCheckpoint;
        rb2d.linearVelocity = Vector2.zero;
        numSaltos = 0;
        recibiendoDaño = false;
    }

    public void CargarEscenaMuerte()
    {
        SceneManager.LoadScene("Muerte");
    }
    void PerderVidaPorCaida()
    {
        if (muerto || recibiendoDaño)
        {
            return;
        }

        estadisticas.RestarVida();

        if (estadisticas.vidas <= 0)
        {
            muerto = true;
            estadoAnimacion = 6;
            rb2d.linearVelocity = Vector2.zero;
            playerAnimator.SetInteger("estado", estadoAnimacion);
        }
        else
        {
            transform.position = posicionCheckpoint;
            rb2d.linearVelocity = Vector2.zero;
            numSaltos = 0;
        }
    }


}
