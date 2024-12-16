using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    Animator animator;
    AttackDetector attackDetector;

    [SerializeField] public float rangoPatada = 3f;
    [SerializeField] public float rangoJab = 2f;
    [SerializeField] int danioPatada = 20;
    [SerializeField] int danioJab = 10;
    [SerializeField] int daniolowlKick = 20;
    [SerializeField] int danioSpecialKick = 50;

    public void InitializeReferences(Animator animator, AttackDetector attackDetector)
    {
        this.animator = animator;
        this.attackDetector = attackDetector;
    }

    // Método para realizar el ataque Jab
    public void AtaqueJab()
    {
        animator.SetTrigger("jab");
        attackDetector.JabCollider(danioJab); 
    }

    // Método para realizar el ataque High Kick
    public void AtaqueHighKick()
    {
        animator.SetTrigger("highKick");
        attackDetector.HighKickCollider(danioPatada);
    }

    // Método para realizar el ataque Special Kick
    public void AtaqueSpecialKick()
    {
        animator.SetTrigger("specialKick");
        attackDetector.ChestCollider(danioSpecialKick);
    }

    // Método para realizar el ataque Special Kick
    public void AtaqueLowKick()
    {
        animator.SetTrigger("lowKick");
        attackDetector.LowCollider(daniolowlKick);
    }
}
