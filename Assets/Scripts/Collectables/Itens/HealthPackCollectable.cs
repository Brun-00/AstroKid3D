using Itens;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthPackCollectable : ItemCollectableBase
{
    // Add one life pack when collected.
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.LifePack, 1);
    }
}