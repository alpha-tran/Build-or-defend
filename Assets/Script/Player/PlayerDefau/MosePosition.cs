using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MosePosition : MonoBehaviour
{
    [SerializeField] private  InputActionReference _actionClick;
    public DataMose dataMose;
    [SerializeField] private Transform _target;
    private void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (_actionClick.action.triggered)
        {
            var mosePosition = dataMose._actionMousePosition.action.ReadValue<Vector2>();
            Ray aimingRay = dataMose._camera.ScreenPointToRay(mosePosition);
            if (Physics.Raycast(aimingRay, out var hitInfo, dataMose._maxDistance, dataMose._checkLayer))
            {
                _target.position = hitInfo.point;
            }
        }
    }
}
