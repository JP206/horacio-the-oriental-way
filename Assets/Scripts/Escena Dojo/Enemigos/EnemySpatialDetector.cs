using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpatialDetector : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float rayLength;

    AtaqueEnemigo ataqueEnemigo;
    MovimientoEnemigo movimientoEnemigo;
    VidaJugador vidaJugador;

    public void InitializeReferences(AtaqueEnemigo _ataqueEnemigo, MovimientoEnemigo _movimientoEnemigo, VidaJugador _jugador)
    {
        ataqueEnemigo = _ataqueEnemigo;
        movimientoEnemigo = _movimientoEnemigo;
        vidaJugador = _jugador;

        Debug.Log($"References initialized: AtaqueEnemigo={ataqueEnemigo}, MovimientoEnemigo={movimientoEnemigo}, Jugador={vidaJugador}");
    }

    void Update()
    {
        if (vidaJugador == null)
        {
            Debug.LogError("Jugador no asignado en EnemySpatialDetector. Revisa la inicialización.");
            return;
        }

        Vector2 direccion = transform.position.x - vidaJugador.transform.position.x > 0 ? Vector2.left : Vector2.right;
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