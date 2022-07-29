using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerView _playerView;

    [Header("SO")]
    [SerializeField] private CameraSO _cameraSO;
    [SerializeField] private MouseSO _mouseSO;
    [SerializeField] private PlayerSO _playerSO;

    //Model
    private MouseModel _mouseModel;
    private InputModel _inputModel;

    // Controllers
    private List<IControllerUpdate> _controllersUpdate;
    private List<IControllerFixedUpdate> _controllersFixedUpdate;

    private MouseController _mouseController;
    private InputController _inputController;
    private CameraRotateController _cameraRotateController;
    private PlayerRotateController _playerRotateController;
    private PlayerMoveController _playerMoveController;


    private void Awake()
    {
        InitializeModels();
        InitializeControllers();
        InitializeSubscribes();
        InitializeListUpdate();
        InitializeListFixedUpdate();
    }

    private void InitializeModels()
    {
        _mouseModel = new MouseModel();
        _inputModel = new InputModel();
    }

    private void InitializeControllers()
    {
        _mouseController = new MouseController(_mouseModel, _mouseSO);
        _inputController = new InputController(_inputModel);
        _cameraRotateController = new CameraRotateController(_mouseModel, _cameraView);
        _playerRotateController = new PlayerRotateController(_playerView, _mouseModel);
        _playerMoveController = new PlayerMoveController(_playerView, _playerSO, _inputModel);
    }

    private void InitializeSubscribes()
    {
        _mouseModel.MouseMove += _cameraRotateController.CameraRotate;
        _mouseModel.MouseMove += _playerRotateController.PlayerRotate;

        _inputModel.InputMove += _playerMoveController.PlayerMove;
    }

    private void InitializeListUpdate()
    {
        _controllersUpdate = new List<IControllerUpdate>();
        _controllersUpdate.Add(_mouseController);
        _controllersUpdate.Add(_inputController);
    }

    private void InitializeListFixedUpdate()
    {
        _controllersFixedUpdate = new List<IControllerFixedUpdate>();
        _controllersFixedUpdate.Add(_inputController);
    }

    private void Update()
    {
        foreach(var controller in _controllersUpdate)
        {
            controller.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach(var controller in _controllersFixedUpdate)
        {
            controller.FixedUpdate();
        }
    }
}
