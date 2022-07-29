using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    public GameObject Camera => _camera;
}
