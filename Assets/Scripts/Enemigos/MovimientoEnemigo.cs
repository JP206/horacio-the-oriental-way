using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] float velocidadCorrer;
    
    SpriteRenderer enemyRenderer;
    Animator animator;
    float xVelocidad, yVelocidad;
    float deltaX => xVelocidad * Time.fixedDeltaTime;
    float deltaY => yVelocidad * Time.deltaTime;

    public void InitializeReferences(Animator _animator, SpriteRenderer _spriteRenderer)
    {
        enemyRenderer = _spriteRenderer;
        animator = _animator;
    }

    void FixedUpdate()
    {
        var vectorMovimiento = new Vector3(deltaX, deltaY);
        transform.Translate(vectorMovimiento);
    }

    public void MovimientoX(float xValue)
    {
        xVelocidad = xValue * velocidadCorrer;

        animator.SetFloat("xVelocidad", Mathf.Abs(xVelocidad));

        if (deltaX < 0) enemyRenderer.flipX = true;
        else if (deltaX > 0) enemyRenderer.flipX = false;
    }
}
