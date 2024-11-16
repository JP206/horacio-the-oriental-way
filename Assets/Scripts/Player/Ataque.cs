using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    Animator animator;
    SpacialDetector detector;
    Movimiento movmientoJugador;

    [SerializeField] public float rangoPatada = 3f;
    [SerializeField] public float rangoJab = 2f;
    [SerializeField] int danioPatada = 20;
    [SerializeField] int danioJab = 10;
    [SerializeField] int danioSpecialKick = 50;

    public void InitializeReferences(
        Animator animator, 
        SpacialDetector detector,
        Movimiento movmientoJugador
        )
    {
        this.animator = animator;
        this.detector = detector;
        this.movmientoJugador = movmientoJugador;
    }

    // Activo Trigger Jab
    public void AtaqueJab()
    {
        detector.DetectarEnemigo(movmientoJugador.direccionActual, rangoJab);
        animator.SetTrigger("jab");
    }

    // Activo Trigger High Kick
    public void AtaqueHighKick()
    {
        animator.SetTrigger("highKick");
    }

    // Activo Trigger Special Kick
    public void AtaqueSpecialKick()
    {
        animator.SetTrigger("specialKick");
    }
}
