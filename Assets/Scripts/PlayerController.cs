using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float MoveDistance = 1.0f;
    [Range(1f, 20f)]
    public float jumpForce = 5f ;

    private Vector3 startPosition;

    private Rigidbody _rb;

    private ICommand _wCommand;
    private ICommand _upArrowCommand;    
    private ICommand _aCommand;
    private ICommand _sCommand;
    private ICommand _dCommand;
    private ICommand _rCommand;
    private ICommand _spaceCommand;

    private ICommand _lastCommand; //keep track of the last command
    private ICommand _nextCommand;

    //last in first out = stack, so we need 2 stacks
    //undo stack and redo stack of ICommands
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    //replay stack is new Stack<ICommand>(undoStack.ToArray())
    private Stack<ICommand> replayStack;

    private void HandleInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //w was pressed
            _wCommand.Execute();
            undoStack.Push(_wCommand);
            redoStack.Clear();
            
            //_lastCommand = _wCommand;
           // _nextCommand = null;
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            //up arrow pressed
            _upArrowCommand.Execute();
            undoStack.Push(_upArrowCommand);
            redoStack.Clear();
           // _lastCommand = _upArrowCommand;
            //_nextCommand = null;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            //a was pressed
            _aCommand.Execute();
            undoStack.Push(_aCommand);
            redoStack.Clear();
            // _lastCommand = _aCommand;
            // _nextCommand = null;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            //s was pressed
            _sCommand.Execute();
            undoStack.Push(_sCommand);
            redoStack.Clear();
            // _lastCommand = _sCommand;
            // _nextCommand = null;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            //d was pressed
            _dCommand.Execute();
            undoStack.Push(_dCommand);
            redoStack.Clear();
//             _lastCommand = _dCommand;
//             _nextCommand = null;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //space was pressed
            _spaceCommand.Execute();
            undoStack.Push(_spaceCommand);
            redoStack.Clear();
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            InvertControls();
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            UndoCommand();
            // if (_lastCommand != null)
            // {
            //     ICommand activeCommand = undoStack.Pop();
            //     activeCommand.Undo();
                
            //     _nextCommand = _lastCommand;
            //     _lastCommand = null;
            // }
            
           
        }
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            RedoCommand();
            // if (_nextCommand != null)
            // {
            //     _nextCommand.Execute();
            //     _lastCommand = _nextCommand;
            //     _nextCommand = null;
            // }
                

        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            //transform.position = startPosition;
            ReplayCommands();
        }
    }

    private void UndoCommand()
    {
        //active command is popped from undoStack and add that command to redoStack
       if (undoStack.Count > 0)
        {            
            ICommand activeCommand = undoStack.Pop();            
            redoStack.Push(activeCommand);
            activeCommand.Undo();
        }

    }
    private void RedoCommand()
    {
        //active command is popped from undoStack and add that command back to redoStack
        if(redoStack.Count > 0)
        {
        ICommand activeCommand = redoStack.Pop();
        undoStack.Push(activeCommand);
        activeCommand.Execute();
        }
    }
    private IEnumerator Replay(Stack<ICommand> commands)
    {
        //for each loop that executes commands in replayStack
        foreach (ICommand cmd in commands)
        {
            //wait for resetting position before executing first command
            yield return new WaitForSeconds(0.5f);
            cmd.Execute();
            
        }
        //commands.Clear();
    }
    private void ReplayCommands()
    {
        //reset position to start and create a reversed undoStack with:
            //new Stack<ICommand>(undoStack.ToArray());
        //start a coroutine that executes the commands in the replayStack
        transform.position = startPosition;
        replayStack = new Stack<ICommand>(undoStack.ToArray());        
        StartCoroutine(Replay(replayStack));       


    }

    private void InvertControls()
    {
        //inverting controls
        Debug.Log("inverting controls");
        (_wCommand, _sCommand) = (_sCommand, _wCommand);

        (_aCommand, _dCommand) = (_dCommand, _aCommand);
    }

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //create a forward-command
        _upArrowCommand = new MoveForwardCommand(transform, MoveDistance);
        _wCommand = new MoveForwardCommand(transform, MoveDistance);
        _aCommand = new MoveLeftCommand(transform, MoveDistance);
        _sCommand = new MoveBackwardCommand(transform, MoveDistance);
        _dCommand = new MoveRightCommand(transform, MoveDistance);
        _spaceCommand = new JumpCommand(_rb, jumpForce);
        _lastCommand = null;
        _nextCommand = null;
        //_wCommand = new MoveForwardCommand(transform, MoveDistance);
        _rb = GetComponent<Rigidbody>(); //Get player's rigibBody component
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
