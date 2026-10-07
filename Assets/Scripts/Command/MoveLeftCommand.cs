using System.Xml.Serialization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeftCommand : ICommand
{
    private float _amount;
    private Transform _transform;

    public MoveLeftCommand(Transform transform, float amount)
    {
        _transform = transform;
        _amount = amount;
    }

    public void Execute()
    {
        Debug.Log("L command exec");
        _transform.Translate(_amount * Vector3.left, Space.World);
    }
    public void Undo()
    {
        Debug.Log("L command undo");
        _transform.Translate(-_amount * Vector3.left, Space.World);
    }
}
