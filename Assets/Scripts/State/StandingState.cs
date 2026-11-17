using UnityEngine;
using UnityEngine.InputSystem;

public class StandingState : PlayerStateBase
{
    public override void Enter(PlayerController player)
    {
        Debug.Log("Entered Standing State");
    }

    public override PlayerStateBase HandleInput(PlayerController player)
    {
        // Transition to Jumping
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            player.ExecuteJump();
            return new JumpingState();
        }

        // Transition to Crouching
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            player.ExecuteCrouch();
            return new CrouchingState();
        }

        // Stay in Standing state
        return this;
    }
}
