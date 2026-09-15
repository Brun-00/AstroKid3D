using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerScript;

public class PowerUPSuperJump : PowerUPBase
{
    // Apply the Super Jump power-up to the current player.
    protected override void StartPowerUp()
    {
        GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().ApplyPowerUp(PowerUpType.SuperJump, duration);
    }
}