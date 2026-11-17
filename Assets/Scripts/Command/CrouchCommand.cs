//using System.Numerics;
using UnityEngine;

public class CrouchCommand : ICommand
{
    private bool _active = false;
public Transform _transform;

public CrouchCommand(Transform transform)
    {
     _transform = transform;
    }
  public void Execute()
    { //crouch by making the player object smaller in y
        Vector3 scale = _transform.localScale;
        if (!_active)
        {
            scale.y *= 0.5f;
            _transform.localScale = scale;
            _active = true;
        }
        else
        {
            scale.y *= 2f;
            _transform.localScale = scale;
            _active = false;
        }
        Debug.Log("crouch command exec!");
    }
public void Undo()
    {
        Execute();
    }
}
