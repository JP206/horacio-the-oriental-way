using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public void DetectOnX(float xValue)
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
