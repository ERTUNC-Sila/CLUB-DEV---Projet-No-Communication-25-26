using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Jetpack _jetpack;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        _jetpack = GetComponentInChildren<Jetpack>();
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

    public void OnJetpack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _jetpack.StartJetpack();
        }

        if (context.canceled)
        {
            _jetpack.StopJetpack();
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerMovement.AddSpeed();
        }

        if (context.canceled)
        {
            _playerMovement.RemoveSpeed();
        }

    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("throw");
        }

    }

}
