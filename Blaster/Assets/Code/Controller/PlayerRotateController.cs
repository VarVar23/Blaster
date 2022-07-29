using UnityEngine;

public class PlayerRotateController
{
    private PlayerView _playerView;
    private MouseModel _mouseModel;

    public PlayerRotateController(PlayerView playerView, MouseModel mouseModel)
    {
        _playerView = playerView;
        _mouseModel = mouseModel;
    }

    public void PlayerRotate()
    {
        _playerView.PlayerBody.transform.localRotation = Quaternion.Euler(0, _mouseModel.MouseX, 0);
    }
}
