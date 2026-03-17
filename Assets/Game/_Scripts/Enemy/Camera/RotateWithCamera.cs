using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    void Update()
    {
        transform.rotation = GameManager.Instance.CurrentCam.transform.rotation;
    }
}
