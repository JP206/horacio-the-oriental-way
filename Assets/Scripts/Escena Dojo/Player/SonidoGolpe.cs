using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoGolpe : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip golpe1, golpe2, golpe3;

    public void InitializeReferences(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }

    public void HighSound()
    {
        audioSource.PlayOneShot(golpe1);
    }

    public void ChestSound()
    {
        audioSource.PlayOneShot(golpe2);
    }

    public void LowSound()
    {
        audioSource.PlayOneShot(golpe3);
    }
}
