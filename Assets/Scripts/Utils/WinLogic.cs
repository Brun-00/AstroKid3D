using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogic : MonoBehaviour
{
    public GameObject winScreen;
    public BoxCollider winCollider;
    public AudioSource winSound;
    public ParticleSystem winParticles;
    public int currentLevel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable player movement and show the win screen.
            GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().characterController.enabled = false;
            winScreen.SetActive(true);
            winSound.Play();
            winParticles.Play();
            winCollider.enabled = false;

            SaveManager.Instance.SaveLastLevel(currentLevel);

            SaveManager.Instance.ResetCheckpoint();
        }
    }
}