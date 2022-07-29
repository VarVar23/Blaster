using UnityEngine;
public interface IWeaponView
{
    public float ReloadingSpeed { get; }
    public float DistanceShoot { get; }
    public int CountBulletAll { get; }
    public int CountBulletNow { set;  get; }
    public Transform PointShoot { get; }

}
