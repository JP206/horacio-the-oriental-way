using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    //Importacion de Scripts para inicializar el juego
    [SerializeField] Movimiento movimientoJugador;
    [SerializeField] Animator animacion;
    [SerializeField] SpacialDetector detector;
    [SerializeField] Ataque ataque;
    [SerializeField] VidaEnemigo enemigo;
    [SerializeField] VidaJugador jugador;
    void Start()
    {
        ataque.InitializeReferences(animacion, detector, movimientoJugador);
        jugador.InitializeReferences(animacion);
    }

    //Activo el movimiento X del script Movimiento (Jugador)
    public void MovimientoEnX(float xValue) { movimientoJugador.DetectarEjeX(xValue); }

    // Llamo al método de Ataque (Jab)
    public void OnJab() { ataque.AtaqueJab(); }

    // Llamo al método de Ataque (High Kick)
    public void OnHighKick() { ataque.AtaqueHighKick(); }

    // Llamo al metodo de Ataque (Special Kkick)
    public void OnSpecialKick() { ataque.AtaqueSpecialKick(); }
}
