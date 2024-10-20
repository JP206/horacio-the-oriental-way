using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    //Importacion de Scripts para inicializar el juego
    [SerializeField] Movimiento movimientoJugador;
    [SerializeField] Salto salto;
    [SerializeField] Animator animacion;
    [SerializeField] SpacialDetector detector;
    [SerializeField] Ataque ataque;
    void Start()
    {
        movimientoJugador.InitializeReferences(detector, animacion);
        salto.InitializeReferences(detector, movimientoJugador, animacion);
        ataque.InitializeReferences(animacion, detector);
    }

    //Activo el movimiento X del script Movimiento (Jugador)
    public void MovimientoEnX(float xValue) { movimientoJugador.MovimientoX(xValue); }
    public void Salto() { salto.Saltando(); }

    // Llamo al m�todo de Ataque (Jab)
    public void OnJab() { ataque.AtaqueJab(); }

    // Llamo al m�todo de Ataque (High Kick)
    public void OnHighKick() { ataque.AtaqueHighKick(); }
}
