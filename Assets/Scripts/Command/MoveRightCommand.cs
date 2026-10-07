using System.Xml.Serialization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveRightCommand : ICommand
{
    private float _amount;
    private Transform _transform;

    public MoveRightCommand(Transform transform, float amount)
    {
        _transform = transform;
        _amount = amount;
    }

    public void Execute()
    {
        Debug.Log("R command exec");
        _transform.Translate(_amount * Vector3.right, Space.World);
    }
    public void Undo()
    {
        Debug.Log("L command undo");
        _transform.Translate(-_amount * Vector3.right, Space.World);
    }
}
