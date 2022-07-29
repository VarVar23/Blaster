using UnityEngine;

public class CameraRotateController
{
    private MouseModel _mouseModel;
    private CameraView _cameraView;

    public CameraRotateController(MouseModel mouseModel, CameraView cameraView)
    {
        _mouseModel = mouseModel;
        _cameraView = cameraView;
    }

    public void CameraRotate()
    {
        Debug.Log("Камера повернулась");
        _cameraView.Camera.transform.localRotation = Quaternion.Euler(-_mouseModel.MouseY, 0, 0);
    }

}
