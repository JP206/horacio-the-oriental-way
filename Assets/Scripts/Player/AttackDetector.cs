using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    [SerializeField] private float rayLength = 0.3f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform highRayOrigin;
    [SerializeField] private Transform middleRayOrigin;
    [SerializeField] private Transform lowRayOrigin;

    VidaEnemigo enemigo;

    public void InitializeReferences(VidaEnemigo enemigo)
    {
        this.enemigo = enemigo;
    }

    // Método para detectar un enemigo con un Raycast
    public void HighCollider(int danio)
    {
        // Dirección del rayo (basado en la orientación del personaje)
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Lanza el Raycast
        RaycastHit2D hit = Physics2D.Raycast(highRayOrigin.position, direction, rayLength, enemyLayer);

        // Dibuja el rayo para depuración
        Debug.DrawRay(highRayOrigin.position, direction * rayLength, Color.red, 0.5f);

        // Verifica si golpea algo
        if (hit.collider != null)
        {
            // Comprueba si es el collider específico "CabezaEnemigo"
            if (hit.collider.CompareTag("CabezaEnemigo"))
            {
                enemigo.RecibirDanio(danio, "high");
            }
        }
    }

    public void ChestCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(middleRayOrigin.position, direction, rayLength, enemyLayer);

        Debug.DrawRay(middleRayOrigin.position, direction * rayLength, Color.blue, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("TorsoEnemigo"))
            {
                enemigo.RecibirDanio(danio, "chest");
            }
        }
    }

    public void LowCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(lowRayOrigin.position, direction, rayLength, enemyLayer);

        Debug.DrawRay(lowRayOrigin.position, direction * rayLength, Color.black, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("PiernasEnemigo"))
            {
                enemigo.RecibirDanio(danio, "low");
            }
        }
    }
}
