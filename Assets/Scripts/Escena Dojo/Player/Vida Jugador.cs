using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    SpriteRenderer spriteRenderer;

    // Propiedades de la vida del jugador
    public int vidaMaxima;
    int vidaActual;
    bool esInvulnerable = false;
    bool golpeCabezaActivo = false;

    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private string gameOverSceneName = "GameOver";

    public void InitializeReferences(Animator animator, InputManager inputManager, SpriteRenderer spriteRenderer)
    {
        this.animator = animator;
        this.inputManager = inputManager;
        this.spriteRenderer = spriteRenderer;

        vidaActual = vidaMaxima;
    }

    public int VidaActual()
    {
        return vidaActual;
    }

    // Método para recibir daño
    public void RecibirDanio(int danio)
    {
        // Evito daño mientras Horacio es invulnerable
        if (esInvulnerable) return;

        Debug.Log($"RecibirDanio llamado con {danio} de daño. Vida actual antes de daño: {vidaActual - 1}");

        // Resto el daño a la vida actual
        vidaActual -= danio;

        // Si la Vida del jugador es igual a 0, llama a Muerte()
        if (vidaActual == 0)
        {
            Muerte();
            return;
        }

        // Si no ha muerto, ejecuta las corrutinas
        StartCoroutine(EjecutarGolpeCabeza());
        StartCoroutine(HacerInvulnerable(0.5f));
        StartCoroutine(Tintineo());
    }

    // Método para manejar la muerte del jugador
    private void Muerte()
    {
        StopAllCoroutines();
        inputManager.HoracioVivo(false);
        animator.SetTrigger("Caida");

        // Inicia la corrutina para esperar el final de la animación y luego iniciar el fade
        StartCoroutine(WaitForAnimationAndFadeOut());
    }

    IEnumerator HacerInvulnerable(float tiempo)
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(tiempo);
        esInvulnerable = false;
    }

    IEnumerator EjecutarGolpeCabeza()
    {
        if (golpeCabezaActivo) yield break;
        golpeCabezaActivo = true;

        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("golpeEnCabeza");
        golpeCabezaActivo = false;
    }

    private IEnumerator WaitForAnimationAndFadeOut()
    {
        // Espera hasta que el Animator entre en el estado "Caida"
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Caida"))
        {
            yield return null;
        }

        // Ahora que esta en "Caida", espera a que la animación termine
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1f) 
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        // Una vez que la animacion ha terminado, inicia el fade-out
        StartCoroutine(FadeOutAndLoadScene());
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        // Si el CanvasGroup no esta asignado, lanza una advertencia
        if (fadeCanvas == null)
        {
            Debug.LogError("No se ha asignado un CanvasGroup para el efecto de fade.");
            yield break;
        }

        // FadeCanvas comienza en 0
        fadeCanvas.alpha = 0f;

        // Incrementa el alpha del CanvasGroup gradualmente
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Cuando el fade-out termina, carga la escena de Game Over
        SceneManager.LoadScene(gameOverSceneName);
    }

    private IEnumerator Tintineo()
    {
        // Realiza efecto de tintineo cuando lo golpean.
        float r = spriteRenderer.color.r;
        float g = spriteRenderer.color.g;
        float b = spriteRenderer.color.b;
        float tiempo = 0.08f;

        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.color = new Color(r, g, b, 0);
            yield return new WaitForSeconds(tiempo);
            spriteRenderer.color = new Color(r, g, b, 1);
            yield return new WaitForSeconds(tiempo);
        }
    }
}
