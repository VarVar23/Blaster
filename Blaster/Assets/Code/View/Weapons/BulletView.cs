using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _bulletRigidbody;

    public int Damage => _damage;
    public Rigidbody BulletRigidbody => _bulletRigidbody;
}
