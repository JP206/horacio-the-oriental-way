using System.Collections;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaximaEnemigoGris = 20;
    private int vidaActual;

    Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float duracionTintineo = 2f;
    [SerializeField] private float intervaloTintineo = 0.1f;
    [SerializeField] private float tiempoAntesDeTintinear = 1f;

    private bool isDead = false; // bandera para evitar ejecutar Muerte() mas de una vez

    public void InitializeReferences(Animator animator)
    {
        this.animator = animator;
    }

    public void SetupEnemy()
    {
        // Inicializa el SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un SpriteRenderer en el objeto.");
        }

        // Inicializa la vida actual
        vidaActual = vidaMaximaEnemigoGris;

        // Reinicia el estado de muerte
        isDead = false;
    }

    public void RecibirDanio(int danio, string typoDanio)
    {
        // No procesa daño si el enemigo ya esta muerto
        if (isDead) return; 

        vidaActual -= danio;

        // Activa la animación correspondiente al tipo de daño
        if (typoDanio == "jab" || typoDanio == "high") { animator.SetTrigger("enemyHeadHit"); }
        else if (typoDanio == "chest") { animator.SetTrigger("enemyChestHit"); }
        else if (typoDanio == "low") { animator.SetTrigger("enemyLegHit"); }

        // Checkeo si el enemigo tiene vida 0
        if (vidaActual <= 0) { Muerte(); }
    }

    private void Muerte()
    {
        // Logica de muerte se ejecuta una sola ves
        if (isDead) return;

        // Marca al enemigo como muerto
        isDead = true; 

        // Activa los parametros de animacion de muerte
        animator.SetBool("isDead", true);
        animator.SetTrigger("enemyDead");

        // Desactiva todos los colliders hijos
        DesactivarColliders();

        // Inicia la corrutina para el tintineo y destrucción
        StartCoroutine(TintinearYDesactivar());
    }

    private void DesactivarColliders()
    {
        // Obtengo los colliders y todos su hijos
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

        foreach (var col in colliders)
        {
            // Desactiva cada collider
            col.enabled = false;
        }
    }

    private IEnumerator TintinearYDesactivar()
    {
        //Obtengo la referencia del enemigo directamente del metodo
        SetupEnemy();

        // Espera un tiempo antes de comenzar el tintineo
        yield return new WaitForSeconds(tiempoAntesDeTintinear);

        // Obtengo la el tiempo de la animacion estaMuerto
        float tiempoAnimacion = 0f;
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("isDead"))
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            tiempoAnimacion = stateInfo.length;
        }

        // Empieza a tintinear mientras se ejecuta la animación
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionTintineo)
        {
            // Alterna la visibilidad
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Espera un intervalo de tiempo
            yield return new WaitForSeconds(intervaloTintineo);

            // Incrementa el tiempo transcurrido
            tiempoTranscurrido += intervaloTintineo;
        }

        // Apago el sprite antes de destruir al enemigo
        spriteRenderer.enabled = false;

        // Espera a que termine la animacion antes de destruir
        yield return new WaitForSeconds(Mathf.Max(0f, tiempoAnimacion - duracionTintineo));

        // Finalmente destruye el objeto
        //Destroy(gameObject);

        // Desactivo el objeto para que quede en el pool
        gameObject.SetActive(false);
    }
}
