using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float MoveDistance = 1.0f;
    [Range(1f, 20f)]
    public float jumpForce = 5f ;

    private Rigidbody _rb;

    private void HandleInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //w was pressed
            transform.Translate(MoveDistance * Vector3.forward, Space.World);
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            //a was pressed
            transform.Translate(MoveDistance * Vector3.left, Space.World);
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            //s was pressed
            transform.Translate(MoveDistance * Vector3.back, Space.World);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            //d was pressed
            transform.Translate(MoveDistance * Vector3.right, Space.World);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //space was pressed
            _rb.AddForce(jumpForce* Vector3.up, ForceMode.Impulse);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); //Get player's rigibBody component
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
