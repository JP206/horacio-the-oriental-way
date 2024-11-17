using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpatialDetector : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float rayLength;

    AtaqueEnemigo ataqueEnemigo;
    MovimientoEnemigo movimientoEnemigo;
    GameObject jugador;

    public void InitializeReferences(AtaqueEnemigo _ataqueEnemigo, MovimientoEnemigo _movimientoEnemigo, GameObject _jugador)
    {
        ataqueEnemigo = _ataqueEnemigo;
        movimientoEnemigo = _movimientoEnemigo;
        jugador = _jugador;
    }

    void Update()
    {
        Vector2 direccion = transform.position.x - jugador.transform.position.x > 0 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, rayLength, collisionLayer);
        Debug.DrawRay(transform.position, direccion * rayLength, Color.red);

        if (hit.collider != null)
        {
            movimientoEnemigo.MovimientoX(0);

            if (hit.collider.CompareTag("Player"))
            {
                ataqueEnemigo.Ataque();
            }
        }
        else
        {
            if (direccion == Vector2.left)
            {
                movimientoEnemigo.MovimientoX(-1);
            }
            else
            {
                movimientoEnemigo.MovimientoX(1);
            }
        }
    }
}