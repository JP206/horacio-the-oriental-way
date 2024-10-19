using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    //Importacion de Scripts para inicializar el juego
    [SerializeField] Movimiento movimientoJugador;
    [SerializeField] Animator animacion;
    [SerializeField] SpacialDetector detector;
   
    void Start()
    {
        movimientoJugador.InitializeReferences(detector, animacion);
    }

    //Activo el movimiento X del script Movimiento (Jugador)
    public void MovimientoEnX(float xValue) { movimientoJugador.MovimientoX(xValue); }
}
