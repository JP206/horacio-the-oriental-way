using UnityEngine;

public class SpacialDetector : MonoBehaviour
{
    [SerializeField] float alturaActor;
    [SerializeField] float anchoActor;
    [SerializeField] LayerMask collisionLayer, enemigoLayerMask;

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

    public VidaEnemigo DetectarEnemigo(float direction, float lookAhead)
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y);
        Vector2 rayDirection = Vector2.right * direction;

        // Lanza el Raycast para detectar objetos en la capa especificada
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, anchoActor / 2f + lookAhead, enemigoLayerMask);
        Debug.DrawRay(rayOrigin, (rayDirection * lookAhead), Color.blue, 2);

        // Verifica si el raycast detectó un objeto y si este objeto tiene el tag "Enemigo"
        if (hit.collider != null && hit.collider.CompareTag("Enemigo"))
        {
            // Si el objeto tiene el tag "Enemigo", devuelve el componente VidaEnemigo
            return hit.collider.GetComponent<VidaEnemigo>();
        }
        else
        {
            // Si no se detecta un enemigo, retorna null
            return null;
        }
    }

}
