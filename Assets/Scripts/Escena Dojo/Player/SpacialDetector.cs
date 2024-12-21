using UnityEngine;

public class SpacialDetector : MonoBehaviour
{
    [SerializeField] float alturaActor;
    [SerializeField] float anchoActor;
    [SerializeField] LayerMask enemigoLayerMask;

    public VidaEnemigo DetectarEnemigo(Quaternion direccion, float lookAhead)
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y);
        Vector2 rayDireccion = direccion * Vector2.right;

        // Lanza el Raycast para detectar objetos en la capa especificada
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDireccion, anchoActor / 2f + lookAhead, enemigoLayerMask);
        Debug.DrawRay(rayOrigin, (rayDireccion * lookAhead), Color.blue, 2);

        // Verifica si el raycast detectó un objeto y si este objeto tiene el tag "Enemigo"
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
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
