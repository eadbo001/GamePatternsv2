using UnityEngine;

public class JumpingState : PlayerStateBase
{
    public override void Enter(PlayerController player)
    {
        Debug.Log("Entered Jumping State");
    }

    public override PlayerStateBase HandleInput(PlayerController playerf)
    {
        
        // transition back to Standing with collision detection on the ground.
        return this;
    }
}
