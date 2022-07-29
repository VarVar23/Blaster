using UnityEngine;
using System.Collections.Generic;

public class SpawnStartBulletsController : IControllerStart
{
    private Transform _bulletParent;
    private GameObject _bulletPrefab;
    private BulletsModel _bulletModel;
    private IWeaponView _weaponView;

    public SpawnStartBulletsController(Transform bulletParent, GameObject bulletPrefab, BulletsModel bulletModel, IWeaponView weaponView)
    {
        _bulletParent = bulletParent;
        _bulletPrefab = bulletPrefab;
        _bulletModel = bulletModel;
        _weaponView = weaponView;
    }

    public void Start()
    {
        var coutBullet = _weaponView.CountBulletNow;
        _bulletModel.BulletsStack = new Stack<BulletView>();

        for(int i = 0; i < coutBullet; i++)
        {
            var bullet = GameObject.Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity, _bulletParent).GetComponent<BulletView>();
            _bulletModel.BulletsStack.Push(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}
