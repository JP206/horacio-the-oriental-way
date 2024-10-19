using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] float velocidadCorrer;

    SpacialDetector detector;
    Animator animator;
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
    }

    public void MovimientoX(float xValue)
    {
        // Calculo velocidad de moviento * el valor de X
        xVelocidad = xValue + velocidadCorrer;

        // Actualizar el animator con la velocidad en X
        animator.SetFloat("xVelocidad", Mathf.Abs(xVelocidad));

        // Manejar la orientación del personaje
        if (deltaX < 0f) playerRenderer.flipX = true;
        else if (deltaX > 0) playerRenderer.flipX = false;

    }
}
