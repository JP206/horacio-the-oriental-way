using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para acceder al componente Image

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

    // Referencia a la barra de vida (Imagen con FillAmount)
    [SerializeField] private Image barraDeVida;

    public void InitializeReferences(Animator animator, InputManager inputManager, SpriteRenderer spriteRenderer, Image barraDeVida)
    {
        this.animator = animator;
        this.inputManager = inputManager;
        this.spriteRenderer = spriteRenderer;
        this.barraDeVida = barraDeVida;

        vidaActual = vidaMaxima;
        ActualizarBarraDeVida();
    }

    public int VidaActual()
    {
        return vidaActual;
    }

    // Método para recibir daño
    public void RecibirDanio(int danio, Vector3 posicionAtacante)
    {
        if (esInvulnerable) return;

        Debug.Log($"RecibirDanio llamado con {danio} de daño. Vida actual antes de daño: {vidaActual}");

        vidaActual -= danio;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        ActualizarBarraDeVida(); 
        if (vidaActual <= 0)
        {
            Muerte();
            return;
        }

        bool golpeDesdeIzquierda = posicionAtacante.x < transform.position.x;
        StartCoroutine(EjecutarGolpeCabeza(golpeDesdeIzquierda));

        StartCoroutine(HacerInvulnerable(0.5f));
        StartCoroutine(Tintineo());
    }

    // Método para actualizar el FillAmount de la barra de vida
    private void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vidaActual / vidaMaxima;
        }
        else
        {
            Debug.LogWarning("Barra de vida no asignada en el Inspector.");
        }
    }

    private void Muerte()
    {
        StopAllCoroutines();
        inputManager.HoracioVivo(false);
        animator.SetTrigger("Dead");
        StartCoroutine(WaitForAnimationAndFadeOut());
    }

    IEnumerator HacerInvulnerable(float tiempo)
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(tiempo);
        esInvulnerable = false;
    }

    IEnumerator EjecutarGolpeCabeza(bool posicionAtacante)
    {
        if (golpeCabezaActivo) yield break;
        golpeCabezaActivo = true;

        animator.SetTrigger(posicionAtacante ? "neckHit" : "faceHit");
        golpeCabezaActivo = false;
    }

    private IEnumerator WaitForAnimationAndFadeOut()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            yield return null;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1f)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        StartCoroutine(FadeOutAndLoadScene());
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        if (fadeCanvas == null)
        {
            Debug.LogError("No se ha asignado un CanvasGroup para el efecto de fade.");
            yield break;
        }

        fadeCanvas.alpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(gameOverSceneName);
    }

    private IEnumerator Tintineo()
    {
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
