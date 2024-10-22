using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SceneInitializer initializer;
    void Update()
    {
        initializer.MovimientoEnX(DetectarMovimientoHorizontal());
        DetectarInputSalto();
        DetectarAtaque();
    }

    float DetectarMovimientoHorizontal()
    {
        //GetAxisRaw() Genera "Smooth" en el movimiento del personaje 
        return Input.GetAxisRaw("Horizontal");
    }

    void DetectarInputSalto()
    {
        if (Input.GetButtonDown("Jump")) { initializer.Salto(); }
    }

    void DetectarAtaque()
    {
        if (Input.GetButtonDown("Jab")) { initializer.OnJab(); }
        if (Input.GetButtonDown("HighKick")) { initializer.OnHighKick(); }
        if (Input.GetButtonDown("SpecialKick")) { initializer.OnSpecialKick(); }
        if (Input.GetButtonDown("FlyingKick")) { initializer.OnFlyingKick(); }
    }
}
