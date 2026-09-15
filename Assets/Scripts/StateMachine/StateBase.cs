using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    // Called when the state becomes active.
    public virtual void OnStateEnter(object o = null)
    {
    }

    // Called while the state is active.
    public virtual void OnStateStay(object o = null)
    {
    }

    // Called when the state is no longer active.
    public virtual void OnStateExit(object o = null)
    {
    }
}