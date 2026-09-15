using UnityEngine;
using DG.Tweening;

public class PowerUPBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float duration;

    // Start the power-up and play its collection effect.
    protected override void OnCollect()
    {
        Transform player = GameManager.Instance.currentPlayer.GetComponent<PlayerScript>()?.transform;

        if (player == null)
        {
            Debug.LogError("Player não encontrado no momento da coleta!");
            return;
        }

        player.DOScale(1.2f, .2f)
              .SetEase(Ease.OutBack)
              .SetLoops(2, LoopType.Yoyo);

        StartPowerUp();

        base.OnCollect();
    }

    // Start the power-up duration timer.
    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
    }

    // Called when the power-up duration ends.
    protected virtual void EndPowerUp()
    {
    }
}