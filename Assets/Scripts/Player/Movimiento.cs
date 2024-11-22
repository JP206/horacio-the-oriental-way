using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerRenderer;

    public void DetectarEjeX(float xValue)
    {
        if (xValue > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xValue < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
