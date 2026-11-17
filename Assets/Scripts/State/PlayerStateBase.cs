using UnityEngine;

public abstract class PlayerStateBase
{
    public virtual void Enter(PlayerController player) {}

    public abstract PlayerStateBase HandleInput(PlayerController player);

    public virtual void Exit(PlayerController player) {}
}
