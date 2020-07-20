using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    // Add methods that we want in a state
    #region public abstract Methods
    public abstract void EnterState(PlayerController player);
    public abstract void Update(PlayerController player);
    public abstract void OnCollisionEnter(PlayerController player);
    #endregion
}
