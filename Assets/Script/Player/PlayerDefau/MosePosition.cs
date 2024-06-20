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
            var mosePosition = dataMose.ActionMousePosition.action.ReadValue<Vector2>();
            Ray aimingRay = dataMose.Camera.ScreenPointToRay(mosePosition);
            if (Physics.Raycast(aimingRay, out var hitInfo, dataMose.MaxDistance, dataMose.CheckLayer))
            {
                _target.position = hitInfo.point;
            }
        }
    }
}
