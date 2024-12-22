using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] bool rightJab = false;
    [SerializeField] int _jabDamage; 
    public int JabDamage
    {
        get => _jabDamage; 
        set => _jabDamage = Mathf.Max(0, value); 
    }

    Animator animator;
    VidaJugador vidaJugador;
    AudioSource audioSource;

    // Especie de semaforo para permitir atacar si se llama varias veces Ataque()
    bool canAttack = true; 
    
    public void InitializeReferences(Animator _animator, VidaJugador _vidaJugador, AudioSource _audioSource)
    {
        animator = _animator;
        vidaJugador = _vidaJugador;
        audioSource = _audioSource;
    }

    public void Ataque()
    {
        // Verifico si el enemigo tiene un Animator activo (indicando que sigue vivo)
        if (!animator || animator.GetBool("isDead")) return;

        // Verifico las condiciones del ataque
        if (rightJab && canAttack && vidaJugador.VidaActual() > 0)
        {
            StartCoroutine(ataque());
            canAttack = false;
            animator.SetTrigger("rightJab");
            vidaJugador.RecibirDanio(JabDamage, transform.position);
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    IEnumerator ataque()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
