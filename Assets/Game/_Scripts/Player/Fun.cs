using FeedbacksEditor;
using UnityEngine;

/// <summary>
/// Gun, mais j'ai écrit Fun sans faire exprès c'est plus drôle
/// </summary>
public class Fun : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private LayerMask _shootLayerMask;
    [SerializeField] private GameEvent _shootFeedback;
    [SerializeField] private int _damageByShot;
    [SerializeField] private Vector3 _recoilForce;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot
            GameEventsManager.PlayEvent(_shootFeedback, gameObject);
            if (Physics.Raycast(GameManager.Instance.CurrentCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _shootLayerMask))
            {
                if (hit.collider.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(_damageByShot);
                }
            }
            
            // Recoil
            _player.AddExternalForces(Vector3.Scale(-GameManager.Instance.CurrentCam.transform.forward, _recoilForce));
        }
    }
}