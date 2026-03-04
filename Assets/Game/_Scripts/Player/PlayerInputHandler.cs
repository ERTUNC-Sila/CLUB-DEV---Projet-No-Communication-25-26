using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;
 
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMovement.SetMoveInput(context.ReadValue<Vector2>());
    }

    //public void OnJump(InputAction.CallbackContext context)
    //{
       
    //    if (context.performed)
    //    {
    //        if (_playerMovement.IsGrounded())
    //        {
    //            _playerMovement.Jump();
    //        }

    //    }
        
    //}

    public void OnFuelHeld(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        if (context.canceled)
        {

        }
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //_carryController.TryThrow();
        }

    }

}
