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

    void Start()
    {
        ataqueEnemigo = GetComponent<AtaqueEnemigo>();
        enemySpatialDetector = GetComponent<EnemySpatialDetector>();
        movimientoEnemigo = GetComponent<MovimientoEnemigo>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jugador = GameObject.FindWithTag("Player");

        ataqueEnemigo.InitializeReferences(animator);
        enemySpatialDetector.InitializeReferences(ataqueEnemigo, movimientoEnemigo, jugador);
        movimientoEnemigo.InitializeReferences(animator, spriteRenderer);
    }
}
