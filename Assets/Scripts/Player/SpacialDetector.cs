using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialDetector : MonoBehaviour
{
    [SerializeField] float alturaActor;
    [SerializeField] float anchoActor;
    [SerializeField] LayerMask collisionLayer;

    //Genera un rayo que apunta a la direccion asignada en el vector
    //Si el raycast detecta desde la posicion en la que se encuentra un objeto con el que colisiona
    public bool esPiso(float minLookAhead, float lookAhead)
    {
        var totalLookAhead = Mathf.Abs(lookAhead) + minLookAhead;

        Debug.DrawRay(transform.position + new Vector3(0, alturaActor / 2), Vector2.down * (alturaActor + totalLookAhead), Color.black, 0.1f);

        return Physics2D.Raycast(transform.position + new Vector3(0, alturaActor / 2), Vector2.down, alturaActor + totalLookAhead, collisionLayer);
    }
}
