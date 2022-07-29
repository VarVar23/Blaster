using UnityEngine;

[CreateAssetMenu(menuName = "Config/PlayerSO", fileName = "PlayerSO", order = 0)]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
