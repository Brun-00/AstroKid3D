using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : ItemCollectableBase
{
    public GameObject wallPFB;

    // Remove the wall when the boss key is collected.
    protected override void OnCollect()
    {
        base.OnCollect();
        wallPFB.SetActive(false);
    }
}