using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerScript;

public class PowerUPMegaBullets : PowerUPBase
{
    // Apply the Mega Bullets power-up to the current player.
    protected override void StartPowerUp()
    {
        GameManager.Instance.currentPlayer.GetComponent<PlayerScript>().ApplyPowerUp(PowerUpType.MegaBullets, duration);
    }
}