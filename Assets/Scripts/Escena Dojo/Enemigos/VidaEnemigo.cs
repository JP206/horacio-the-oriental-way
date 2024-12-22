using System.Collections;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int maxHpGrayEnemy = 20;
    private int currentHp;

    Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float blinkDuration = 2f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private float timeBeforeBlink = 1f;

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
        currentHp = maxHpGrayEnemy;

        // Reinicia el estado de muerte
        isDead = false;
    }

    public void ReceiveDamage(int damage, string damageType)
    {
        // No procesa daño si el enemigo ya esta muerto
        if (isDead) return; 

        currentHp -= damage;

        // Activa la animación correspondiente al tipo de daño
        if (damageType == "jab" || damageType == "high") { animator.SetTrigger("enemyHeadHit"); }
        else if (damageType == "chest") { animator.SetTrigger("enemyChestHit"); }
        else if (damageType == "low") { animator.SetTrigger("enemyLegHit"); }

        // Checkeo si el enemigo tiene vida 0
        if (currentHp <= 0) { Death(); }
    }

    private void Death()
    {
        // Logica de muerte se ejecuta una sola ves
        if (isDead) return;

        // Marca al enemigo como muerto
        isDead = true; 

        // Activa los parametros de animacion de muerte
        animator.SetBool("isDead", true);
        animator.SetTrigger("enemyDead");

        // Desactiva todos los colliders hijos
        DisableColliders();

        // Inicia la corrutina para el tintineo y destrucción
        StartCoroutine(BlinkAndDisable());
    }

    private void DisableColliders()
    {
        // Obtengo los colliders y todos su hijos
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

        foreach (var col in colliders)
        {
            // Desactiva cada collider
            col.enabled = false;
        }
    }

    private IEnumerator BlinkAndDisable()
    {
        //Obtengo la referencia del enemigo directamente del metodo
        SetupEnemy();

        // Espera un tiempo antes de comenzar el tintineo
        yield return new WaitForSeconds(timeBeforeBlink);

        // Obtengo la el tiempo de la animacion estaMuerto
        float animationTime = 0f;
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("isDead"))
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            animationTime = stateInfo.length;
        }

        // Empieza a tintinear mientras se ejecuta la animación
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            // Alterna la visibilidad
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Espera un intervalo de tiempo
            yield return new WaitForSeconds(blinkInterval);

            // Incrementa el tiempo transcurrido
            elapsedTime += blinkInterval;
        }

        // Apago el sprite antes de destruir al enemigo
        spriteRenderer.enabled = false;

        // Espera a que termine la animacion antes de destruir
        yield return new WaitForSeconds(Mathf.Max(0f, animationTime - blinkDuration));

        // Desactivo el objeto para que quede en el pool
        gameObject.SetActive(false);
    }
}
