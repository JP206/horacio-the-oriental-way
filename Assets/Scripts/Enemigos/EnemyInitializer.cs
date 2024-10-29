using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    AtaqueEnemigo ataqueEnemigo;
    EnemySpatialDetector enemySpatialDetector;
    MovimientoEnemigo movimientoEnemigo;
    Animator animator;
    GameObject jugador;
    SpriteRenderer spriteRenderer;
    VidaJugador vidaJugador;

    void Start()
    {
        ataqueEnemigo = GetComponent<AtaqueEnemigo>();
        enemySpatialDetector = GetComponent<EnemySpatialDetector>();
        movimientoEnemigo = GetComponent<MovimientoEnemigo>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jugador = GameObject.FindWithTag("Player");

        vidaJugador = jugador.GetComponent<VidaJugador>();
        Debug.Log("vidaJugador asignado: " + vidaJugador);

        ataqueEnemigo.InitializeReferences(animator, vidaJugador);
        enemySpatialDetector.InitializeReferences(ataqueEnemigo, movimientoEnemigo, jugador);
        movimientoEnemigo.InitializeReferences(animator, spriteRenderer);
    }
}
