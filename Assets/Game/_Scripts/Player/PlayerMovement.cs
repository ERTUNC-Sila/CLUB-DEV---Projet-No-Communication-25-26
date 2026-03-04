using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 _moveDir { get; set; }

    [Header("Movement Parameters")]
    [SerializeField] private float _speed = 6;
    //[SerializeField] private float _acceleration = 30f;
    //[SerializeField] private float _deceleration = 40f;
    [SerializeField] private float _turnSpeed = 10f;

    private Vector2 _moveInput;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetMoveInput(Vector2 moveInput)
    {
        _moveInput = moveInput;
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();

    }

    private void HandleMovement()
    {
        Camera cam = GameManager.Instance.CurrentCam;

        Vector3 forward = _moveInput.y * cam.transform.forward;
        Vector3 right = _moveInput.x * cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        _moveDir = forward + right;

        _rb.linearVelocity = _moveDir * _speed;
        //_rb.AddForce(_moveDir * _speed, ForceMode.Force);

    }

    void HandleRotation()
    {
        if (_moveInput.sqrMagnitude < 0.1f || _moveDir.sqrMagnitude < 0.1f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), _turnSpeed * Time.fixedDeltaTime);
        transform.rotation = newRotation;
    }



}
