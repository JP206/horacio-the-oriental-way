using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] float cooldownAtaques;
    [SerializeField] bool golpeDerecha;
    [SerializeField] int _danioJab; 
    public int DanioJab
    {
        get => _danioJab; 
        set => _danioJab = Mathf.Max(0, value); 
    }

    Animator animator;
    VidaJugador vidaJugador;
    AudioSource audioSource;

    // Especie de semaforo para permitir atacar si se llama varias veces Ataque()
    bool puedeAtacar = true; 
    
    public void InitializeReferences(Animator _animator, VidaJugador _vidaJugador, AudioSource _audioSource)
    {
        animator = _animator;
        vidaJugador = _vidaJugador;
        audioSource = _audioSource;
    }

    public void Ataque()
    {
        // Verifico si el enemigo tiene un Animator activo (indicando que sigue vivo)
        if (!animator || animator.GetBool("isMuerto")) return;

        // Verifico las condiciones del ataque
        if (golpeDerecha && puedeAtacar && vidaJugador.VidaActual() > 0)
        {
            StartCoroutine(ataque());
            puedeAtacar = false;
            animator.SetTrigger("golpeDerecha");
            vidaJugador.RecibirDanio(DanioJab, transform.position);
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    IEnumerator ataque()
    {
        yield return new WaitForSeconds(cooldownAtaques);
        puedeAtacar = true;
    }
}
