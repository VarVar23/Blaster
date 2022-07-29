using UnityEngine;
public class InputController : IControllerUpdate, IControllerFixedUpdate
{
    private InputModel _inputModel;

    public InputController(InputModel inputModel)
    {
        _inputModel = inputModel;
    }

    public void Update()
    {
        _inputModel.InputHorizontal = Input.GetAxis("Horizontal");
        _inputModel.InputVertical = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        if(_inputModel.InputHorizontal != 0 || _inputModel.InputVertical != 0)
        {
            _inputModel.InputMove.Invoke();
        }
    }
}
