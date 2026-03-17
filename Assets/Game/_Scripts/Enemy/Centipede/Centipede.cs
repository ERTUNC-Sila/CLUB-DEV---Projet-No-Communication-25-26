using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;


public class Centipede : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private GameObject _eyePrefab;
    [SerializeField] private SplineContainer _spline;

    [Header("Parameters")]
    [SerializeField] private int _eyesNumber = 7;

    [SerializeField] private float _targetOffset = 0.01f;
    [SerializeField] private float _splineSpeed = 15;

#if UNITY_EDITOR
    public void CreateCentipede()
    {
        // Destroy previous children
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
        }

        // Spawn new children
        for (int i = 0; i < _eyesNumber; i++)
        {
            var instance = GameManager.Instantiate(_eyePrefab, _targetTransform);
            var splineAnimate = instance.AddComponent<SplineAnimate>();
            splineAnimate.Container = _spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.MaxSpeed = _splineSpeed;
            splineAnimate.StartOffset = _targetOffset * i;
            //Selection.activeGameObject = instance;
        }

        // Re-select target transform
        //Selection.activeGameObject = _targetTransform.gameObject;
    }
#endif
}