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
        // Inicializamos la vida al valor m�ximo al comenzar
        vidaActual = vidaMaximaEnemigoGris;
        return vidaActual;
    }

    // M�todo para recibir da�o
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

    // M�todo para manejar la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El vidaMaximaEnemigoGris ha muerto.");
    }
}
