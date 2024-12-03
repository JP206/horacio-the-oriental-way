using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] SceneInitializer initializer;
    bool horacioVivo = true;
    [SerializeField]
    Button botonBajoDerecha, botonBajoIzquierda, botonMedioDerecha, botonMedioIzquierda,
        botonAltoDerecha, botonAltoIzquierda, botonEspecial;

    void Start()
    {
        botonBajoDerecha.onClick.AddListener(BajoDerecha);
        botonBajoIzquierda.onClick.AddListener(BajoIzquierda);

        botonMedioDerecha.onClick.AddListener(MedioDerecha);
        botonMedioIzquierda.onClick.AddListener(MedioIzquierda);

        botonAltoDerecha.onClick.AddListener(AltoDerecha);
        botonAltoIzquierda.onClick.AddListener(AltoIzquierda);

        botonEspecial.onClick.AddListener(AtaqueEspecial);
    }

    void Update()
    {
        if (horacioVivo)
        {
            initializer.MovimientoEnX(DetectarMovimientoHorizontal());
            DetectarAtaque();
        }
    }

    float DetectarMovimientoHorizontal()
    {
        //GetAxisRaw() Genera "Smooth" en el movimiento del personaje 
        return Input.GetAxisRaw("Horizontal");
    }

    void DetectarAtaque()
    {
        if (Input.GetButtonDown("Jab")) { initializer.OnJab(); } // Boton X
        if (Input.GetButtonDown("HighKick")) { initializer.OnHighKick(); } // Boton Z
        if (Input.GetButtonDown("SpecialKick")) { initializer.OnSpecialKick(); } // Boton C
        if (Input.GetButtonDown("LowKick")) { initializer.OnLowKick(); } // Boton V
    }

    public void HoracioVivo(bool vivo)
    {
        horacioVivo = vivo;
    }

    void BajoDerecha()
    {
        initializer.MovimientoEnX(1);
        initializer.OnLowKick();
    }

    void BajoIzquierda()
    {
        initializer.MovimientoEnX(-1);
        initializer.OnLowKick();
    }

    void MedioDerecha()
    {
        initializer.MovimientoEnX(1);
        initializer.OnHighKick();
    }

    void MedioIzquierda()
    {
        initializer.MovimientoEnX(-1);
        initializer.OnHighKick();
    }

    void AltoDerecha()
    {
        initializer.MovimientoEnX(1);
        initializer.OnJab();
    }

    void AltoIzquierda()
    {
        initializer.MovimientoEnX(-1);
        initializer.OnJab();
    }

    void AtaqueEspecial()
    {
        initializer.OnSpecialKick();
    }
}
