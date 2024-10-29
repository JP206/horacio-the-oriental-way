using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    // Propiedades de la vida del jugador
    public int vidaMaximaEnemigoGris = 20;
    private int vidaActual;

    public int VidaActual()
    {
        // Inicializamos la vida al valor máximo al comenzar
        vidaActual = vidaMaximaEnemigoGris;
        return vidaActual;
    }

    // Método para recibir daño
    public void RecibirDanio(int danio)
    {
        VidaActual();
        vidaActual -= danio;
        vidaMaximaEnemigoGris = vidaActual;

        // Verificamos si la vida llega a cero o menos
        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    // Método para manejar la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El vidaMaximaEnemigoGris ha muerto.");
    }
}
