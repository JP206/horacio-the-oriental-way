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
            Debug.LogError("No se encontr� un SpriteRenderer en el objeto.");
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

        // Activa la animaci�n de muerte
        animator.SetTrigger("estaMuerto");

        // Inicia la corrutina para el tintineo y destrucci�n
        StartCoroutine(TintinearYDestruir());
    }

    private IEnumerator TintinearYDestruir()
    {
        // Espera un tiempo antes de comenzar el tintineo
        yield return new WaitForSeconds(tiempoAntesDeTintinear);

        // Obt�n la duraci�n de la animaci�n "estaMuerto"
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float tiempoAnimacion = stateInfo.length;

        // Empieza a tintinear mientras se ejecuta la animaci�n
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

        // Aseg�rate de que el sprite est� apagado antes de destruir
        spriteRenderer.enabled = false;

        // Espera a que termine la animaci�n antes de destruir
        yield return new WaitForSeconds(tiempoAnimacion - duracionTintineo);

        // Finalmente destruye el objeto
        Destroy(gameObject);
    }
}
