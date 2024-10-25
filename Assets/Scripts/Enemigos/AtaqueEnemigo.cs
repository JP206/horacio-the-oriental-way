using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] float cooldownAtaques;
    [SerializeField] bool golpeDerecha;

    Animator animator;
    bool puedeAtacar = true; // Especie de semaforo para permitir atacar si se llama varias veces Ataque()
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Ataque()
    {
        if (golpeDerecha && puedeAtacar) StartCoroutine(ataque());
    }

    IEnumerator ataque()
    {
        puedeAtacar = false;
        animator.SetTrigger("golpeDerecha");
        yield return new WaitForSeconds(cooldownAtaques);
        puedeAtacar = true;
    }
}
