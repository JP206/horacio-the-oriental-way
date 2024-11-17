using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SceneInitializer initializer;
    void Update()
    {
        initializer.MovimientoEnX(DetectarMovimientoHorizontal());
        DetectarAtaque();
    }

    float DetectarMovimientoHorizontal()
    {
        //GetAxisRaw() Genera "Smooth" en el movimiento del personaje 
        return Input.GetAxisRaw("Horizontal");
    }

    void DetectarAtaque()
    {
        if (Input.GetButtonDown("Jab")) { initializer.OnJab(); } // Boton X
        if (Input.GetButtonDown("HighKick")) { initializer.OnHighKick(); } // Boton Z
        if (Input.GetButtonDown("SpecialKick")) { initializer.OnSpecialKick(); } // Boton C
        if (Input.GetButtonDown("LowKick")) { initializer.OnLowKick(); } // Boton V
    }
}
