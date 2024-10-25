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

    void Start()
    {
        ataqueEnemigo = GetComponent<AtaqueEnemigo>();
        jugador = GameObject.FindWithTag("Player");
        movimientoEnemigo = GetComponent<MovimientoEnemigo>();
        ataqueEnemigo = GetComponent<AtaqueEnemigo>();
        // no se si ta bien esto, porque los enemigos aparecen dinamicamente y no se pueden asignar en el inspector a SceneInitializer
    }

    void Update()
    {
        Vector2 direccion = transform.position.x - jugador.transform.position.x > 0 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, rayLength, collisionLayer);
        Debug.DrawRay(transform.position, direccion * rayLength, Color.red);
        
        if (hit.collider != null)
        {
            movimientoEnemigo.MovimientoX(0);
            ataqueEnemigo.Ataque();
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
