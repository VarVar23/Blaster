using UnityEngine;

[CreateAssetMenu(menuName = "Config/MouseSO", fileName = "MouseSO", order = 0)]
public class MouseSO : ScriptableObject
{
    [SerializeField] private float _mouseSens;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    public float MouseSens => _mouseSens;
    public float MinY => _minY;
    public float MaxY => _maxY;
}
