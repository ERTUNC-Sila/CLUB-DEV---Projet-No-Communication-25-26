using FeedbacksEditor;
using UnityEngine;

/// <summary>
/// Gun, mais j'ai écrit Fun sans faire exprès c'est plus drôle
/// </summary>
public class Fun : MonoBehaviour
{
    [SerializeField] private GameEvent _shootFeedback;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("BOOM");
            GameEventsManager.PlayEvent(_shootFeedback, gameObject);
        }
    }
}