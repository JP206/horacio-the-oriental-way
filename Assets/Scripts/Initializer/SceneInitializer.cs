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
        Physics2D.IgnoreCollision(collider1, collider2);
        movimientoJugador.InitializeReferences(detector, animacion);
        salto.InitializeReferences(detector, movimientoJugador, animacion);
        ataque.InitializeReferences(animacion, detector, movimientoJugador);

    }

    //Activo el movimiento X del script Movimiento (Jugador)
    public void MovimientoEnX(float xValue) { movimientoJugador.MovimientoX(xValue); }
    public void Salto() { salto.Saltando(); }

    // Llamo al método de Ataque (Jab)
    public void OnJab() { ataque.AtaqueJab(); }

    // Llamo al método de Ataque (High Kick)
    public void OnHighKick() { ataque.AtaqueHighKick(); }

    // Llamo al metodo de Ataque (Special Kkick)
    public void OnSpecialKick() { ataque.AtaqueSpecialKick(); }

    // Llamo al metodo de Ataque (Special Kick)
    public void OnFlyingKick() { ataque.AtaqueFlyingKick(); }
}
