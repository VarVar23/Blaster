using UnityEngine;
public class ShootController 
{
    private CameraView _cameraView;
    private IWeaponView _weaponView;
    private BulletsModel _bulletModel;
    private Vector3 _direction;

    public ShootController(CameraView cameraView, IWeaponView weaponView, BulletsModel bulletModel)
    {
        _cameraView = cameraView;
        _weaponView = weaponView;
        _bulletModel = bulletModel;
    }

    public void Shoot()
    {
        if (!CheckCountBullet())
        {
            Debug.Log("Звук пустого магазина");
            return;
        }

        ChangeDirection();

        _weaponView.CountBulletNow--;
        var bullet = _bulletModel.BulletsStack.Pop();

        bullet.transform.SetParent(null);
        bullet.transform.position = _weaponView.PointShoot.position;
        bullet.transform.rotation = _weaponView.PointShoot.transform.rotation;
        bullet.gameObject.SetActive(true);
        bullet.BulletRigidbody.AddForce(_direction * (_weaponView.DistanceShoot * 0.2f), ForceMode.Impulse);

       
        //Debug.Log("Произошел выстрел, пуль осталось: " + _weaponView.CountBulletNow + " \nВ стеке осталось: " + _bulletModel.BulletsStack.Count);
    }

    private bool CheckCountBullet()
    {
        return _weaponView.CountBulletNow > 0;
    }

    private void ChangeDirection()
    {
        var vector1 = _cameraView.transform.position + (_cameraView.transform.forward * _weaponView.DistanceShoot);
        var vector2 = _weaponView.PointShoot.transform.position;
        _direction = vector1 - vector2;
        _direction.Normalize();
    }
}
