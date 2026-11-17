using UnityEngine;
using UnityEngine.InputSystem;

public class CrouchingState : PlayerStateBase
{
    public override void Enter(PlayerController player)
    {
        Debug.Log("Entered Crouched State");
    }

    public override PlayerStateBase HandleInput(PlayerController player)
    {
        // Pressing 'C' again stands the player back up
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            Debug.Log("Standing up from crouch");
            player.ExecuteCrouch();
            return new StandingState();
        }

        return this;
    }
}
