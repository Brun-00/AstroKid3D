using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        // Randomize the pitch slightly to make the sound less repetitive.
        audioSource.pitch = Random.Range(0.6f, 1.4f);
        audioSource.Play();
    }
}
