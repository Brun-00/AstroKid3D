using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : ItemCollectableBase
{
    public GameObject wallPFB;

    protected override void OnCollect()
    {
        base.OnCollect();
        wallPFB.SetActive(false);
    }

}
