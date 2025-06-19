using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static event Action<Vector2> movementPlayer;
    public static event Action jumpEvent;


    public void MovementPlayer(InputAction.CallbackContext context)
    {
        movementPlayer?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpEvent?.Invoke();
    }

}
