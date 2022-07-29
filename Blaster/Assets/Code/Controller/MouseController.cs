using UnityEngine;

public class MouseController : IControllerUpdate
{
    private MouseModel _mouseModel;
    private MouseSO _mouseSO;
    private float _oldMouseX = 0;
    private float _oldMouseY = 0;

    public MouseController(MouseModel mouseModel, MouseSO mouseSO)
    {
        _mouseModel = mouseModel;
        _mouseSO = mouseSO;
    }

    public void Update()
    {
        _mouseModel.MouseX += Input.GetAxis("Mouse X") * _mouseSO.MouseSens * Time.deltaTime;
        _mouseModel.MouseY += Input.GetAxis("Mouse Y") * _mouseSO.MouseSens * Time.deltaTime;

        _mouseModel.MouseY = Mathf.Clamp(_mouseModel.MouseY, _mouseSO.MinY, _mouseSO.MaxY);

        Debug.Log(_mouseModel.MouseX);
        if(_oldMouseX != _mouseModel.MouseX || _oldMouseY != _mouseModel.MouseY)
        {
            _mouseModel.MouseMove.Invoke();

            _oldMouseX = _mouseModel.MouseX;
            _oldMouseY = _mouseModel.MouseY;

            Debug.Log("Сработал метод движения мыши");
        }
    }
}
