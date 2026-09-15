using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

public class EnemyBase : MonoBehaviour, IDamageable
{
    public AnimationBase animationBase;
    public float health = 10f;
    public Transform player;

    public FlashColor flashColor;

    [SerializeField] private float _currentHealth;

    public float startAnimationDuration = 0.5f;
    public Ease ease = Ease.OutBack;
    public bool startWithSpawnAnimation = true;

    public ParticleSystem deathParticle;

    public bool isDead = false;
    public AudioSource deathSound;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;

        CheckPlayerNullity();
        Init();
    }

    protected virtual void Init()
    {
        ResetLife();
    }

    // Reset the enemy's health and spawn state.
    protected void ResetLife()
    {
        _currentHealth = health;
        Spawn();
    }

    protected virtual void Kill()
    {
        OnKill();
    }

    // Handle the enemy death effects and cleanup.
    protected virtual void OnKill()
    {
        GetComponent<BoxCollider>().enabled = false;
        deathSound.pitch = Random.Range(0.6f, 1.4f);
        deathSound.Play();

        if (deathParticle != null)
        {
            deathParticle.Play();
        }

        Destroy(gameObject, 0.8f);
        PlayAnimation(AnimationType.Death);
    }

    // Apply damage and check if the enemy should be defeated.
    public void OnDamage(float f)
    {
        if (flashColor != null)
        {
            flashColor.Flash();
        }

        _currentHealth -= f;

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Spawn()
    {
        if (startWithSpawnAnimation)
            SpawnAnimation();
    }

    // Play the enemy's spawn animation.
    protected virtual Tween SpawnAnimation()
    {
        transform.localScale = Vector3.zero;

        return transform.DOScale(
            originalScale,
            startAnimationDuration
        ).SetEase(ease);
    }

    public void PlayAnimation(AnimationType type, bool value = true)
    {
        animationBase.PlayAnimation(type, value);
    }

    public void Damage(float damage)
    {
        OnDamage(damage);
    }

    // Trigger the attack animation when the player is touched.
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayAnimation(AnimationType.Attack);
        }
    }

    // Find the player if the current reference is missing.
    public void CheckPlayerNullity()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
                player = p.transform;
        }
    }
}