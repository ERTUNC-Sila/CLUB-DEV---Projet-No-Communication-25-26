using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 _moveDir { get; set; }

    [Header("Movement Parameters")]
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _addedSpeed = 5f;
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private Transform _playerGroundTransform;

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

        _moveDir = (forward + right).normalized;

        Vector3 v = _rb.linearVelocity;
        Vector3 targetV = _moveDir * _speed;
        targetV.y = v.y;

        _rb.linearVelocity = targetV;
        //_rb.linearVelocity = _moveDir * _speed;
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

    public void AddSpeed()
    {
        _speed += _addedSpeed;
    }
    public void RemoveSpeed()
    {
        _speed -= _addedSpeed;
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(_playerGroundTransform.transform.position, Vector3.down, 0.2f, LayerMask.GetMask("Ground")))
        {
            return true;
        }

        return false;
    }

}
