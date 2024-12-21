using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneInitializer : MonoBehaviour
{
    // -- Imports -- //
    [SerializeField] InputManager inputManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SonidoGolpe sounds;
    [SerializeField] Image hpBar;

    // -- Player -- //
    [SerializeField] AttackDetector attackDetector;
    [SerializeField] Movimiento playerMovement;
    [SerializeField] SpacialDetector detector;
    [SerializeField] VidaJugador player;
    [SerializeField] Ataque attack;
    [SerializeField] Animator playerAnimator;
    [SerializeField] SpriteRenderer playerSpriteRenderer;

    // -- Enemy List -- //
    [SerializeField] List<GameObject> enemies;

    void Start()
    {
        // Player Initializers
        player.InitializeReferences(playerAnimator, inputManager, playerSpriteRenderer, hpBar);
        attack.InitializeReferences(playerAnimator, attackDetector);
        attackDetector.InitializeReferences(sounds);

        // Scene Initializers
        sounds.InitializeReferences(audioSource);

        // Initialize each enemy in the list
        foreach (GameObject enemy in enemies)
        {
            InitializeEnemy(enemy);
        }
    }

    void InitializeEnemy(GameObject enemy)
    {
        // Obtiene los componentes necesarios del enemigo
        EnemySpatialDetector enemySpatialDetector = enemy.GetComponent<EnemySpatialDetector>();
        SpriteRenderer enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
        MovimientoEnemigo enemyMovement = enemy.GetComponent<MovimientoEnemigo>();
        AtaqueEnemigo enemyAttack = enemy.GetComponent<AtaqueEnemigo>();
        VidaEnemigo enemyVida = enemy.GetComponent<VidaEnemigo>();
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        AudioSource enemyAudio = enemy.GetComponent<AudioSource>();

        // Valida que los componentes no sean nulos
        if (enemySpatialDetector == null || enemySpriteRenderer == null || enemyMovement == null ||
            enemyAttack == null || enemyVida == null || enemyAnimator == null || enemyAudio == null)
        {
            Debug.LogError($"Faltan componentes en el enemigo {enemy.name}");
            return;
        }

        // Inicializa las referencias
        enemyAttack.InitializeReferences(enemyAnimator, player, enemyAudio);
        enemySpatialDetector.InitializeReferences(enemyAttack, enemyMovement, player);
        enemyMovement.InitializeReferences(enemyAnimator, enemySpriteRenderer);
        enemyVida.InitializeReferences(enemyAnimator);
    }

    // Player Movement
    public void XMovement(float xValue) { playerMovement.DetectOnX(xValue); }

    // Player Attack Methods
    public void OnJab() { attack.Jab(); }
    public void OnHighKick() { attack.HighKick(); }
    public void OnSpecialKick() { attack.SpecialKick(); }
    public void OnLowKick() { attack.LowKick(); }
}
