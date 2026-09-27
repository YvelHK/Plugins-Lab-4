using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Vector2 moveInput;

    // Input variables
    private InputAction move, shoot;

    // Start is called before the first frame update
    void Start()
    {
        // Set InputActions
        move = InputSystem.actions.FindAction("Move");
        shoot = InputSystem.actions.FindAction("Attack");

        // Subscribe functions
        move.performed += SetMovement;
        move.canceled += SetMovement;
    }

    private void OnDestroy()
    {
        // Unsubscribe from actions
        move.performed -= SetMovement;
        move.canceled -= SetMovement;
    }
    void SetMovement(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }

    public bool GetShooting()
    {
        return shoot.IsPressed();
    }
}
