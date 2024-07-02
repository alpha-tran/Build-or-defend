using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _camera;

    private void Start() => _camera = Camera.main.transform;

    private void Update() => transform.forward = _camera.forward;
}
