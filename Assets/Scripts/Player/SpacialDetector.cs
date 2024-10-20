using UnityEngine;

public class SpacialDetector : MonoBehaviour
{
    [SerializeField] float alturaActor;
    [SerializeField] float anchoActor;
    [SerializeField] LayerMask collisionLayer;

    //Genera un rayo que apunta a la dirección asignada en el vector
    //Si el raycast detecta desde la posición en la que se encuentra un objeto con el que colisiona
    public bool esPiso(float minLookAhead, float lookAhead)
    {
        var totalLookAhead = Mathf.Abs(lookAhead) + minLookAhead;

        Debug.DrawRay(transform.position + new Vector3(0, alturaActor / 2), Vector2.down * (alturaActor + totalLookAhead), Color.black, 0.1f);

        return Physics2D.Raycast(transform.position + new Vector3(0, alturaActor / 2), Vector2.down, alturaActor + totalLookAhead, collisionLayer);
    }

    public float PisoEnEjeY()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, collisionLayer);

        if (hit.collider != null)
        {
            // Ajusto la posición Y restando una pequeña cantidad para asegurar que el personaje toque el suelo
            return hit.point.y + (alturaActor / 2f);
        }

        return transform.position.y;
    }
}
