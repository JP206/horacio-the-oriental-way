using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    Animator animator;
    
    // Propiedades de la vida del jugador
    public int vidaMaxima = 100; 
    private int vidaActual;
    public void InitializeReferences( Animator animator )
    {
        this.animator = animator;
    }

    public int VidaActual()
    {
        Debug.Log("vidaActual: " + vidaActual);
        // Inicializamos la vida al valor máximo al comenzar
        vidaActual = vidaMaxima;
        return vidaActual;
    }

    // Método para recibir daño
    public void RecibirDanio(int danio)
    {
        VidaActual();
        vidaActual -= danio;
        vidaMaxima = vidaActual;

        // Verificamos si la vida llega a cero o menos
        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    // Método para manejar la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
    }
}