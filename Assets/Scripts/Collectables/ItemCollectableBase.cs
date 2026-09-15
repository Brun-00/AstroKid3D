using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particlePrefab;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    // Handles the general collection process.
    protected virtual void Collect()
    {
        OnCollect();

        if (audioSource != null && audioSource.clip != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;

            AudioSource source = tempAudio.AddComponent<AudioSource>();

            source.clip = audioSource.clip;
            source.volume = audioSource.volume;

            source.pitch = Random.Range(0.6f, 1.4f);

            source.Play();

            Destroy(tempAudio, audioSource.clip.length / source.pitch);
        }

        gameObject.SetActive(false);
    }

    // Handles effects triggered when the item is collected.
    protected virtual void OnCollect()
    {
        if (particlePrefab != null)
        {
            ParticleSystem ps = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            ps.Play();

            Destroy(ps.gameObject, 5);
        }
    }
}