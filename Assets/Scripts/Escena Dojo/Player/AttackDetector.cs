using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    [SerializeField] private float rayLength = 0.3f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform jabRayOrigin;
    [SerializeField] private Transform highRayOrigin;
    [SerializeField] private Transform middleRayOrigin;
    [SerializeField] private Transform lowRayOrigin;

    SonidoGolpe sonidoGolpe;

    public void InitializeReferences(SonidoGolpe sonidoGolpe)
    {
        this.sonidoGolpe = sonidoGolpe;
    }

    // Método para detectar un enemigo con un Raycast
    public void JabCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Lanza el Raycast
        RaycastHit2D hit = Physics2D.Raycast(jabRayOrigin.position, direction, rayLength, enemyLayer);

        // Dibuja el rayo para depuración
        Debug.DrawRay(jabRayOrigin.position, direction * rayLength, Color.red, 0.5f);

        // Verifica si golpea algo
        if (hit.collider != null && hit.collider.CompareTag("CabezaEnemigo"))
        {
            // Busca el componente VidaEnemigo en el objeto golpeado
            VidaEnemigo enemigoGolpeado = hit.collider.GetComponentInParent<VidaEnemigo>();

            if (enemigoGolpeado != null)
            {
                enemigoGolpeado.RecibirDanio(danio, "jab");
                sonidoGolpe.HighSound();
            }
        }
    }

    public void HighKickCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Lanza el Raycast
        RaycastHit2D hit = Physics2D.Raycast(highRayOrigin.position, direction, rayLength, enemyLayer);

        // Dibuja el rayo para depuración
        Debug.DrawRay(highRayOrigin.position, direction * rayLength, Color.green, 0.5f);

        // Verifica si golpea algo
        if (hit.collider != null && hit.collider.CompareTag("CabezaEnemigo"))
        {
            // Busca el componente VidaEnemigo en el objeto golpeado
            VidaEnemigo enemigoGolpeado = hit.collider.GetComponentInParent<VidaEnemigo>();

            if (enemigoGolpeado != null)
            {
                enemigoGolpeado.RecibirDanio(danio, "high");
                sonidoGolpe.HighSound();
            }
        }
    }

    public void ChestCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(middleRayOrigin.position, direction, rayLength, enemyLayer);

        Debug.DrawRay(middleRayOrigin.position, direction * rayLength, Color.blue, 0.5f);
        if (hit.collider != null && hit.collider.CompareTag("TorsoEnemigo"))
        {
            Debug.Log(hit.collider.name);
            VidaEnemigo enemigoGolpeado = hit.collider.GetComponentInParent<VidaEnemigo>();

            if (enemigoGolpeado != null)
            {
                enemigoGolpeado.RecibirDanio(danio, "chest");
                sonidoGolpe.ChestSound();
            }
        }
    }

    public void LowCollider(int danio)
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(lowRayOrigin.position, direction, rayLength, enemyLayer);

        Debug.DrawRay(lowRayOrigin.position, direction * rayLength, Color.black, 0.5f);

        if (hit.collider != null && hit.collider.CompareTag("PiernasEnemigo"))
        {
            VidaEnemigo enemigoGolpeado = hit.collider.GetComponentInParent<VidaEnemigo>();

            if (enemigoGolpeado != null)
            {
                enemigoGolpeado.RecibirDanio(danio, "low");
                sonidoGolpe.LowSound();
            }
        }
    }
}
