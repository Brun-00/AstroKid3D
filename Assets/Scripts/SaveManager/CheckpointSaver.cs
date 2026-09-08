using UnityEngine;
using TMPro;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider checkpointCollider;
    public ParticleSystem checkpointEffect;
    public AudioSource checkpointSound;

    public float textDisplayDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            checkpointSound.Play();
            GameManager.Instance.SetCheckpoint(transform);
            GameManager.Instance.ShowCheckpointText();

            SaveManager.Instance.SavePlayerState(transform.position);

            checkpointEffect.Play();
            checkpointCollider.enabled = false;
        }
    }
}