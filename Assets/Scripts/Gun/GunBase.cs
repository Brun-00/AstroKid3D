using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectilePrefab;
    public Transform shootingPosition;
    public float timeBetweenShots = 0.3f;
    public float speed = 150;
    public AudioSource shootSound;

    private Coroutine _currentCoroutine;

    protected virtual IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    // Create and fire a standard projectile.
    public virtual void Shoot()
    {
        shootSound.pitch = Random.Range(0.6f, 1.4f);
        shootSound.Play();
        var projectile = Instantiate(projectilePrefab);
        projectile.transform.position = shootingPosition.position;
        projectile.transform.rotation = shootingPosition.rotation;
        projectile.speed = speed;

        if (GameManager.Instance.currentPlayer.GetComponent<PlayerScript>() != null && GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().IsMegaBulletsActive())
        {
            projectile.Setup(
                GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().megaBulletDamageMultiplier,
                GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().megaBulletSizeMultiplier
            );
        }
    }

    // Start continuously firing the weapon.
    public void StartShooting()
    {
        StopShooting();
        _currentCoroutine = StartCoroutine(StartShoot());
    }

    // Stop the current shooting coroutine.
    public void StopShooting()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }
}