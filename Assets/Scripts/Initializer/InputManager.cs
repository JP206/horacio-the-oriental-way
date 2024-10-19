using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SceneInitializer initializer;
    void Update()
    {
        initializer.MovimientoEnX(DetectarMovimientoHorizontal());
    }

    float DetectarMovimientoHorizontal()
    {
        //GetAxisRaw() Genera el "Smooth" en el movimiento del personaje 
        return Input.GetAxisRaw("Horizontal");
    }
}
