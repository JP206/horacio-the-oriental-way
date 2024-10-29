using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    Animator animator;
    SpacialDetector detector;
    Movimiento movimientoJugador;

    [SerializeField] public float rangoPatada = 3f;
    [SerializeField] public float rangoJab = 2f;
    [SerializeField] int danioPatada = 20;
    [SerializeField] int danioJab = 10;
    [SerializeField] int danioFlyingKick = 40;
    [SerializeField] int danioSpecialKick = 50;

    public void InitializeReferences(
        Animator animator, 
        SpacialDetector detector,
        Movimiento movimientoJugador
        )
    {
        this.animator = animator;
        this.detector = detector;
        this.movimientoJugador = movimientoJugador;
    }

    // Activo Trigger Jab
    public void AtaqueJab()
    {
        if (detector.esPiso(0.1f, 0))
        {
            Jab();
            animator.SetTrigger("jab");
        }
    }

    // Activo Trigger High Kick
    public void AtaqueHighKick()
    {
        if (detector.esPiso(0.1f, 0))
        {
            HighKick();
            animator.SetTrigger("highKick");
        }
    }

    // Activo Trigger Special Kick
    public void AtaqueSpecialKick()
    {
        if (detector.esPiso(0.1f, 0))
        {
            SpecialKick();
            animator.SetTrigger("specialKick");
        }
    }

    // Activo Trigger Flying Kick
    public void AtaqueFlyingKick()
    {
        if (!detector.esPiso(0.1f, 0))
        {
            FlyingKick();
            animator.SetTrigger("flyingKick");
        }
    }


    public void Jab()
    {
        VidaEnemigo vidaEnemigo = detector.DetectarEnemigo(movimientoJugador.direccion, rangoJab);
        if (vidaEnemigo != null && vidaEnemigo.VidaActual() > 0)
        {
            Debug.Log("DENTRO DE DANIO JAB");
            vidaEnemigo.RecibirDanio(danioJab);
        }
    }

    public void HighKick()
    {
        VidaEnemigo vidaEnemigo = detector.DetectarEnemigo(movimientoJugador.direccion, rangoPatada);
        if (vidaEnemigo != null && vidaEnemigo.VidaActual() > 0)
        {
            vidaEnemigo.RecibirDanio(danioPatada);
        }
    }

    public void SpecialKick()
    {
        VidaEnemigo vidaEnemigo = detector.DetectarEnemigo(movimientoJugador.direccion, rangoPatada);
        if (vidaEnemigo != null && vidaEnemigo.VidaActual() > 0)
        {
            vidaEnemigo.RecibirDanio(danioSpecialKick);
        }
    }

    public void FlyingKick()
    {
        VidaEnemigo vidaEnemigo = detector.DetectarEnemigo(movimientoJugador.direccion, rangoPatada);
        if (vidaEnemigo != null && vidaEnemigo.VidaActual() > 0)
        {
            vidaEnemigo.RecibirDanio(danioFlyingKick);
        }
    }
}
