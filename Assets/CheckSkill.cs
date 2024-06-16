using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckSkill : MonoBehaviour
{
    public DataMose dataMose;

    public void Start()
    {
        
    }

    private void Update()
    {
        var moseRealTime = dataMose._actionMousePosition.action.ReadValue<Vector2>();
        if (moseRealTime != null)
        {
            dataMose._target.position = moseRealTime;
        }
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
