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

    public void InitializeReferences(Animator animator)
    {
        this.animator = animator;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un SpriteRenderer en el objeto.");
        }
        vidaActual = vidaMaximaEnemigoGris;
    }

    public void RecibirDanio(int danio, string typoDanio)
    {
        vidaActual -= danio;

        if (typoDanio == "high") { animator.SetTrigger("hitCabeza"); }
        else if (typoDanio == "chest") { animator.SetTrigger("hitPecho"); }
        else if (typoDanio == "low") { animator.SetTrigger("hitPiernas"); }
        // Checkeo si el enemigo tiene vida 0
        if (vidaActual <= 0) { Muerte(); }
    }

    private void Muerte()
    {
        // Activo Boolean de isMuerto
        animator.SetBool("isMuerto", true);

        // Activa la animación de muerte
        animator.SetTrigger("estaMuerto");

        // Inicia la corrutina para el tintineo y destrucción
        StartCoroutine(TintinearYDestruir());
    }

    private IEnumerator TintinearYDestruir()
    {
        // Espera un tiempo antes de comenzar el tintineo
        yield return new WaitForSeconds(tiempoAntesDeTintinear);

        // Obtén la duración de la animación "estaMuerto"
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float tiempoAnimacion = stateInfo.length;

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

        // Asegúrate de que el sprite esté apagado antes de destruir
        spriteRenderer.enabled = false;

        // Espera a que termine la animación antes de destruir
        yield return new WaitForSeconds(tiempoAnimacion - duracionTintineo);

        // Finalmente destruye el objeto
        Destroy(gameObject);
    }
}
