using UnityEngine;

public class SilaController : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    private float _xRotation = 0;
    private float _yRotation = 0;

    // Update is called once per frame
    void Update()
    {
        //Je voulais utiliser l'input system mais mon PC � un bug qui fait que je peut pas le configurer dans l'�diteur :(
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensitivity;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        _yRotation += mouseX;

        GameManager.Instance.CurrentCam.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
