using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] float cooldownAtaques;
    [SerializeField] bool golpeDerecha;
    [SerializeField] int danioJab = 20;

    Animator animator;
    VidaJugador vidaJugador;

    bool puedeAtacar = true; // Especie de semaforo para permitir atacar si se llama varias veces Ataque()
    
    public void InitializeReferences(Animator _animator, VidaJugador _vidaJugador)
    {
        animator = _animator;
        vidaJugador = _vidaJugador;
    }

    public void Ataque()
    {
        if (golpeDerecha && puedeAtacar) {
            StartCoroutine(ataque());

            if (vidaJugador.VidaActual() > 0)
            {
                vidaJugador.RecibirDanio(danioJab);
            }
        }
    }

    IEnumerator ataque()
    {
        puedeAtacar = false;
        animator.SetTrigger("golpeDerecha");
        yield return new WaitForSeconds(cooldownAtaques);
        puedeAtacar = true;
    }
}
