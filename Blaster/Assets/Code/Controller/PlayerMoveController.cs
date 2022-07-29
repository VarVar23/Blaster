using UnityEngine;

public class PlayerMoveController 
{
    private InputModel _inputModel;
    private PlayerView _playerView;
    private PlayerSO _playerSO;
    private Vector3 _direction;

    public PlayerMoveController(PlayerView playerView, PlayerSO playerSO ,InputModel inputModel)
    {
        _inputModel = inputModel;
        _playerView = playerView;  
        _playerSO = playerSO;
    }

    public void PlayerMove()
    {
        _direction = _inputModel.InputHorizontal * _playerView.PlayerBody.transform.right +
            _inputModel.InputVertical * _playerView.PlayerBody.transform.forward;

        _playerView.PlayerRigidbody.velocity = _direction * _playerSO.Speed;
    }
}
