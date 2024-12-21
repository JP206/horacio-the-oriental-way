using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    Animator animator;
    AttackDetector attackDetector;

    [SerializeField] public float kickRange = 3f;
    [SerializeField] public float jabRnage = 2f;
    [SerializeField] int highKickDmg= 20;
    [SerializeField] int JabDmg = 10;
    [SerializeField] int LowKickDmg = 20;
    [SerializeField] int SpecialKickDmg = 50;

    public void InitializeReferences(Animator animator, AttackDetector attackDetector)
    {
        this.animator = animator;
        this.attackDetector = attackDetector;
    }

    // Método para realizar el ataque Jab
    public void Jab()
    {
        animator.SetTrigger("jab");
        attackDetector.JabCollider(JabDmg); 
    }

    // Método para realizar el ataque High Kick
    public void HighKick()
    {
        animator.SetTrigger("highKick");
        attackDetector.HighKickCollider(highKickDmg);
    }

    // Método para realizar el ataque Special Kick
    public void SpecialKick()
    {
        animator.SetTrigger("specialKick");
        attackDetector.ChestCollider(SpecialKickDmg);
    }

    // Método para realizar el ataque Special Kick
    public void LowKick()
    {
        animator.SetTrigger("lowKick");
        attackDetector.LowCollider(LowKickDmg);
    }
}
