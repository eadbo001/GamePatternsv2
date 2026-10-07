using UnityEngine;

public class DoNothing: ICommand
{

    public DoNothing() 
    {

    }
    public void Execute()
        { }
    public void Undo() { }
}
