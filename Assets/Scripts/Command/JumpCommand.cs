using UnityEngine;

public class JumpCommand : ICommand
{
    private Rigidbody _rb;
    private float _amount;

    public JumpCommand(Rigidbody rb, float amount)
    {
        _rb = rb;
        _amount = amount;
    }

    public void Execute()
    {
        _rb.AddForce(_amount * Vector3.up, ForceMode.Impulse);
    }
    public void Undo()
    {
    
    }
}
