using FeedbacksEditor;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _healthPoints;

    [Header("Feedbacks")]
    [SerializeField] private GameEvent _damagedFeedback;
    [SerializeField] private GameEvent _deathFeedback;

    public virtual void TakeDamage(int damage)
    {
        _healthPoints -= Mathf.Max(0, damage);
        GameEventsManager.PlayEvent(_damagedFeedback, gameObject);
        if (_healthPoints <= 0)
        {
            // Death
            GameEventsManager.PlayEvent(_deathFeedback, gameObject);
            gameObject.SetActive(false);
        }
    }
}