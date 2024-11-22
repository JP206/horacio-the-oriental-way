using System.Collections;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    
    // Propiedades de la vida del jugador
    public int vidaMaxima; 
    private int vidaActual;
    bool flag = true;

    public void InitializeReferences( Animator animator, InputManager inputManager )
    {
        this.animator = animator;
        this.inputManager = inputManager;

        // Inicializamos la vida al valor m�ximo al comenzar
        vidaActual = vidaMaxima;
    }

    public int VidaActual()
    {
        return vidaActual;
    }

    // M�todo para recibir da�o
    public void RecibirDanio(int danio)
    {
        vidaActual -= danio;
        //vidaMaxima = vidaActual;

        // Verificamos si la vida llega a cero o menos
        if (vidaActual <= 0 && flag)
        {
            flag = false;
            Muerte();
        }
        else
        {
            StartCoroutine(EjecutarGolpeCabeza());
        }
    }

    // M�todo para manejar la muerte del jugador
    private void Muerte()
    {
        StopAllCoroutines(); //por si quedo un EjecutarGolpeCabeza corriendo, puede interrumpir la animacion de muerte
        inputManager.HoracioVivo(false);
        animator.SetTrigger("Caida");
    }

    IEnumerator EjecutarGolpeCabeza()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("golpeEnCabeza");
    }
}