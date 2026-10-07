using UnityEngine;

public interface ICommand
{
    //all classes that use interface must have and implement the methods
    public void Execute();
    public void Undo();
}
