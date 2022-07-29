using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("SceneObject")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletParent;

    [Header("Views")]
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private AWeapon _weaponView;

    [Header("SO")]
    [SerializeField] private CameraSO _cameraSO;
    [SerializeField] private MouseSO _mouseSO;
    [SerializeField] private PlayerSO _playerSO;

    //Model
    private MouseModel _mouseModel;
    private InputModel _inputModel;
    private BulletsModel _bulletsModel;

    // Controllers
    private List<IControllerUpdate> _controllersUpdate;
    private List<IControllerFixedUpdate> _controllersFixedUpdate;
    private List<IControllerStart> _controllersStart;

    private MouseController _mouseController;
    private InputController _inputController;
    private CameraRotateController _cameraRotateController;
    private PlayerRotateController _playerRotateController;
    private PlayerMoveController _playerMoveController;
    private ShootController _shootController;
    private SpawnStartBulletsController _spawnStartBulletsController;


    private void Awake()
    {
        InitializeModels();
        InitializeControllers();
        InitializeSubscribes();
        InitializeListStart();
        InitializeListUpdate();
        InitializeListFixedUpdate();
    }

    private void InitializeModels()
    {
        _mouseModel = new MouseModel();
        _inputModel = new InputModel();
        _bulletsModel = new BulletsModel();
    }

    private void InitializeControllers()
    {
        _mouseController = new MouseController(_mouseModel, _mouseSO);
        _inputController = new InputController(_inputModel);
        _cameraRotateController = new CameraRotateController(_mouseModel, _cameraView);
        _playerRotateController = new PlayerRotateController(_playerView, _mouseModel);
        _playerMoveController = new PlayerMoveController(_playerView, _playerSO, _inputModel);
        _shootController = new ShootController(_cameraView, _weaponView,_bulletsModel);
        _spawnStartBulletsController = new SpawnStartBulletsController(_bulletParent, _bulletPrefab, _bulletsModel, _weaponView);
    }

    private void InitializeSubscribes()
    {
        _mouseModel.MouseMove += _cameraRotateController.CameraRotate;
        _mouseModel.MouseMove += _playerRotateController.PlayerRotate;
        _mouseModel.MouseClick += _shootController.Shoot;

        _inputModel.InputMove += _playerMoveController.PlayerMove;
    }

    private void InitializeListStart()
    {
        _controllersStart = new List<IControllerStart>();
        _controllersStart.Add(_spawnStartBulletsController);
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

    private void Start()
    {
        foreach(var controller in _controllersStart)
        {
            controller.Start();
        }
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
