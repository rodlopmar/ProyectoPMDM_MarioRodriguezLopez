using System;
using UnityEngine;
using UnityEngine.InputSystem;
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
    LayerMask Suelo;
    Animator playerAnimator;
    int estadoAnimacion = 0;
    bool recibiendoDaño = false;

    void Start()
    {
        movimientoAction = InputSystem.actions.FindAction("Move");
        saltarAction = InputSystem.actions.FindAction("Jump");

        rb2d = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();

        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        Moverse();
        Saltar();

        if (!recibiendoDaño)
        {
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
            else if (!EstaTocandoSuelo())
            {
                if (numSaltos < 2)
                {
                    rb2d.linearVelocityY = velocidadSalto;
                    numSaltos++;
                }
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
        if (collision.gameObject.CompareTag("Pinchos") && !recibiendoDaño)
        {
            recibiendoDaño = true;
            estadoAnimacion = 4;
            playerAnimator.SetInteger("estado", estadoAnimacion);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            TerminarDaño();
        }
    }

    public void TerminarDaño()
    {
        recibiendoDaño = false;
    }




}