﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneInitializer : MonoBehaviour
{
    //Importacion de Scripts para inicializar el juego
    [SerializeField] Movimiento movimientoJugador;
    [SerializeField] Animator animacion;
    [SerializeField] SpacialDetector detector;
    [SerializeField] Ataque ataque;
    [SerializeField] VidaEnemigo enemigo;
    [SerializeField] VidaJugador jugador;
    [SerializeField] AttackDetector attackDetector;
    [SerializeField] InputManager inputManager;
    [SerializeField] SonidoGolpe sonidoGolpe;
    [SerializeField] AudioSource audioSourceHoracio;
    [SerializeField] SpriteRenderer spriteRendererHoracio;
    [SerializeField] Image barraDeVida;
    void Start()
    {
        ataque.InitializeReferences(animacion, attackDetector);
        jugador.InitializeReferences(animacion, inputManager, spriteRendererHoracio, barraDeVida);
        attackDetector.InitializeReferences(sonidoGolpe);
        sonidoGolpe.InitializeReferences(audioSourceHoracio);
    }

    //Activo el movimiento X del script Movimiento (Jugador)
    public void MovimientoEnX(float xValue) { movimientoJugador.DetectarEjeX(xValue); }

    // Llamo al método de Ataque (Jab)
    public void OnJab() { ataque.AtaqueJab(); }

    // Llamo al método de Ataque (High Kick)
    public void OnHighKick() { ataque.AtaqueHighKick(); }

    // Llamo al metodo de Ataque (Special Kick)
    public void OnSpecialKick() { ataque.AtaqueSpecialKick(); }

    //Llamo al metodo de ataque (LowKick)
    public void OnLowKick() { ataque.AtaqueLowKick(); }
}
