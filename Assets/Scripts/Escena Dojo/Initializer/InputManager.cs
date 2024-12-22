using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] SceneInitializer initializer;
    bool horacioIsAlive = true;
    [SerializeField]
    Button lowRightButton, lowLeftButton, midRightButton, midLeftButton,
        highRightButton, highLeftButton, specialButton;

    void Start()
    {
        lowRightButton.onClick.AddListener(LowRight);
        lowLeftButton.onClick.AddListener(LowLeft);

        midRightButton.onClick.AddListener(MidRight);
        midLeftButton.onClick.AddListener(MidLeft);

        highRightButton.onClick.AddListener(HightRight);
        highLeftButton.onClick.AddListener(HighLeft);

        specialButton.onClick.AddListener(SpecialAttack);
    }

    void Update()
    {
        if (horacioIsAlive)
        {
            initializer.XMovement(DetectHorizontalMovement());
            DetectAttack();
        }
    }

    float DetectHorizontalMovement()
    {
        //GetAxisRaw() Genera "Smooth" en el movimiento del personaje 
        return Input.GetAxisRaw("Horizontal");
    }

    void DetectAttack()
    {
        if (Input.GetButtonDown("Jab")) { initializer.OnJab(); } // Boton X
        if (Input.GetButtonDown("HighKick")) { initializer.OnHighKick(); } // Boton Z
        if (Input.GetButtonDown("SpecialKick")) { initializer.OnSpecialKick(); } // Boton C
        if (Input.GetButtonDown("LowKick")) { initializer.OnLowKick(); } // Boton V
    }

    public void HoracioAlive(bool alive)
    {
        horacioIsAlive = alive;
    }

    void LowRight()
    {
        initializer.XMovement(1);
        initializer.OnLowKick();
    }

    void LowLeft()
    {
        initializer.XMovement(-1);
        initializer.OnLowKick();
    }

    void MidRight()
    {
        initializer.XMovement(1);
        initializer.OnHighKick();
    }

    void MidLeft()
    {
        initializer.XMovement(-1);
        initializer.OnHighKick();
    }

    void HightRight()
    {
        initializer.XMovement(1);
        initializer.OnJab();
    }

    void HighLeft()
    {
        initializer.XMovement(-1);
        initializer.OnJab();
    }

    void SpecialAttack()
    {
        initializer.OnSpecialKick();
    }
}
