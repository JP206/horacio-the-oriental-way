using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerRenderer;

    Quaternion direccion;

    public Quaternion direccionActual => direccion;

    public void DetectarEjeX(float xValue)
    {
        if (xValue > 0)
        {
            direccion = Quaternion.Euler(0, 0, 0);
            transform.rotation = direccion;
        }
        else if (xValue < 0)
        {
            direccion = Quaternion.Euler(0, 180, 0);
            transform.rotation = direccion;
        }
    }
}
