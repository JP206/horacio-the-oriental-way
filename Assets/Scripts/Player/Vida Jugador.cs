using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    // Propiedades de la vida del jugador
    public int vidaMaxima = 100; 
    private int vidaActual;

    public int VidaActual()
    {
        // Inicializamos la vida al valor m�ximo al comenzar
        vidaActual = vidaMaxima;
        return vidaActual;
    }

    // M�todo para recibir da�o
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

    // M�todo para manejar la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
    }
}