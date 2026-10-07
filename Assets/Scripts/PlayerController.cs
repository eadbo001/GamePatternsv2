using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float MoveDistance = 1.0f;
    [Range(1f, 20f)]
    public float jumpForce = 5f ;

    private Rigidbody _rb;

    private ICommand _wCommand;
    private ICommand _upArrowCommand;    
    private ICommand _aCommand;
    private ICommand _sCommand;
    private ICommand _dCommand;
    private ICommand _qCommand;

    private ICommand _lastCommand; //keep track of the last command
    private ICommand _nextCommand;

    private void HandleInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //w was pressed
            _wCommand.Execute();
            _lastCommand = _wCommand;
            _nextCommand = null;
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            //up arrow pressed
            _upArrowCommand.Execute();
            _lastCommand = _upArrowCommand;
            _nextCommand = null;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            //a was pressed
            _aCommand.Execute();
            _lastCommand = _aCommand;
            _nextCommand = null;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            //s was pressed
            _sCommand.Execute();
            _lastCommand = _sCommand;
            _nextCommand = null;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            //d was pressed
            _dCommand.Execute();
            _lastCommand = _dCommand;
            _nextCommand = null;
}
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //space was pressed
            _rb.AddForce(jumpForce* Vector3.up, ForceMode.Impulse);
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            InvertControls();
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            if (_lastCommand != null)
            {
                _lastCommand.Undo();
                _nextCommand = _lastCommand;
                _lastCommand = null;
            }
                
           
        }
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            if (_nextCommand != null)
            {
                _nextCommand.Execute();
                _lastCommand = _nextCommand;
                _nextCommand = null;
            }
                

        }
        
    }

    private void InvertControls()
    {
        //inverting controls
        Debug.Log("invertig controls");
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
        _lastCommand = null;
        _nextCommand = null;
        //_wCommand = new MoveForwardCommand(transform, MoveDistance);
        _rb = GetComponent<Rigidbody>(); //Get player's rigibBody component
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
