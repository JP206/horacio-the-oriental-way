using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    Animator animator;
    SpacialDetector detector;

    [SerializeField] public float rangoPatada = 3f;
    [SerializeField] public float rangoJab = 2f;
    [SerializeField] int danioPatada = 20;
    [SerializeField] int danioJab = 10;
    [SerializeField] int danioFlyingKick = 20;
    [SerializeField] int danioSpecialKick = 50;

    public void InitializeReferences(Animator animator, SpacialDetector detector)
    {
        this.animator = animator;
        this.detector = detector;
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

    // Metodos para Detectar enemigos?? -- Agregar lo necesario
    public void Jab()
    {
        Debug.Log("Dentro de Jab");
    }

    public void HighKick()
    {
        Debug.Log("Dentro de HighKick");
    }

    public void SpecialKick()
    {
        Debug.Log("Dentro de Special Kick");
    }

    public void FlyingKick()
    {
        Debug.Log("Dentro de Flying Kick");
    }
}
