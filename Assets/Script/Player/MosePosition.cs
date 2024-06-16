using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MosePosition : MonoBehaviour
{
    
   public DataMose dataMose;
    private void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (dataMose._actionMouseClick.action.triggered)
        {
            var mosePosition = dataMose._actionMousePosition.action.ReadValue<Vector2>();
            Ray aimingRay = dataMose._camera.ScreenPointToRay(mosePosition);
            if (Physics.Raycast(aimingRay, out var hitInfo, dataMose._maxDistance, dataMose._checkLayer))
            {
                dataMose._target.position = hitInfo.point;
            }
        }
    }
}
