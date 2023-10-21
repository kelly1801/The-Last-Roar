using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnRunAction;
    private PlayerInputActions playerInputActions;
    
    private void Awake () {
         playerInputActions = new PlayerInputActions();
         playerInputActions.Player.Enable();
         playerInputActions.Player.Interact.performed += Interact_performed;
         playerInputActions.Player.Run.performed += Run_performed;
    }


     public Vector2 GetMovementVector()
    {
        Vector2 inputVector;

        inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            
        return inputVector;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // null check OnInteractAction
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        
    }

    private void Run_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // null check OnRunAction
            OnRunAction?.Invoke(this, EventArgs.Empty);
        
    }


}
