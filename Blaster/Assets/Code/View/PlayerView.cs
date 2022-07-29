using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private Rigidbody _playerRigidbody;

    public GameObject PlayerBody => _playerBody;
    public Rigidbody PlayerRigidbody => _playerRigidbody;
}
