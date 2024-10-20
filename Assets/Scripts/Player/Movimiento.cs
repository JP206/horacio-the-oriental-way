using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] float velocidadCorrer;
    [SerializeField] float fuerzaDeGravedad;

    SpacialDetector detector;
    Animator animator;
    bool estaSaltando = false;
    float xVelocidad;
    float yVelocidad;
    float deltaX => xVelocidad * Time.fixedDeltaTime;
    float deltaY => yVelocidad * Time.fixedDeltaTime;
    public void InitializeReferences(SpacialDetector detector, Animator animator)
    {
        this.detector = detector;
        this.animator = animator;
    }

    private void FixedUpdate()
    {
        // Movimiento del personaje (horizontal y vertical)
        var vectorMovimiento = new Vector3(deltaX, deltaY);
        transform.Translate(vectorMovimiento);

        MovimientoY();
    }

    public void MovimientoX(float xValue)
    {
        // Calculo velocidad de moviento * el valor de X
        xVelocidad = xValue * velocidadCorrer;

        // Actualizo animator con la velocidad en X
        animator.SetFloat("xVelocidad", Mathf.Abs(xVelocidad));

        // Manej0 la orientación del personaje
        if (deltaX < 0f) playerRenderer.flipX = true;
        else if (deltaX > 0) playerRenderer.flipX = false;
    }

    public void MovimientoY()
    {
        animator.SetFloat("yVelocidad", yVelocidad);

        if (!detector.esPiso(0.1f, deltaY))
        {
            // Controlo la fuerza de gravedad
            yVelocidad -= fuerzaDeGravedad;
        }

        if (detector.esPiso(0.1f, deltaY) && yVelocidad <= 0)
        {
            yVelocidad = 0;

            // Posición del personaje para que esté alineado con el suelo
            Vector2 vector2 = new Vector2(transform.position.x, detector.PisoEnEjeY());
            transform.position = vector2;
        }
    }

    public void AplicarSalto(float fuerzaDeSalto) { yVelocidad += fuerzaDeSalto; }
}
