using UnityEngine;

public class AWeapon : MonoBehaviour, IWeaponView
{
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private float _reloadingSpeed;
    [SerializeField] private float _distanceShoot;
    [SerializeField] private int _countBulletAll;
    [SerializeField] private int _countBulletNow;

    public Transform PointShoot => _pointShoot;
    public float ReloadingSpeed => _reloadingSpeed;
    public float DistanceShoot => _distanceShoot;
    public int CountBulletAll => _countBulletAll;
    public int CountBulletNow { get => _countBulletNow; set => _countBulletNow = value; }
}
