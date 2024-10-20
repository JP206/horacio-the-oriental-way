using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    SpacialDetector detector;
    Movimiento movimientoJugador;
    Animator animator;

    [SerializeField] float fuerzaDeSalto;


    public void InitializeReferences(SpacialDetector detector, Movimiento movimientoJugador, Animator animator)
    {
        this.detector = detector;
        this.movimientoJugador = movimientoJugador;
        this.animator = animator;
    }

    public void Saltando()
    {
        if(detector.esPiso(0.2f, 0))
        {
            // Aplico fuerza de salto al controlador de movimiento
            movimientoJugador.AplicarSalto(fuerzaDeSalto);

            // Setteo el boolean del animator para animacion de salto
            animator.SetTrigger("salto");
        }
    }
}
