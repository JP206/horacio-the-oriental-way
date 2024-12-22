using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    
    SpriteRenderer enemyRenderer;
    Animator animator;
    float xSpeed, ySpeed;
    float deltaX => xSpeed * Time.fixedDeltaTime;
    float deltaY => ySpeed * Time.deltaTime;

    public void InitializeReferences(Animator _animator, SpriteRenderer _spriteRenderer)
    {
        enemyRenderer = _spriteRenderer;
        animator = _animator;
    }

    void FixedUpdate()
    {
        var movementVector = new Vector3(deltaX, deltaY);
        transform.Translate(movementVector);
    }

    public void MovimientoX(float xValue)
    {
        xSpeed = xValue * movementSpeed;

        animator.SetFloat("xVlocity", Mathf.Abs(xSpeed));

        if (deltaX < 0) enemyRenderer.flipX = true;
        else if (deltaX > 0) enemyRenderer.flipX = false;
    }
}
