using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckSkill : MonoBehaviour
{
    public DataMose dataMose;
    public InputActionReference _inputSkill;

    public void Start()
    {
        
    }

    private void Update()
    {
        var moseRealTime = dataMose._actionMousePosition.action.ReadValue<Vector2>();
        Ray aimingRay = dataMose._camera.ScreenPointToRay(moseRealTime);
        //if (moseRealTime != null)
        //{
        //    dataMose._target.position = moseRealTime;

        //    Ray aimingRay = dataMose._camera.ScreenPointToRay(mosePosition);
        //    if (Physics.Raycast(aimingRay, out var hitInfo, dataMose._maxDistance, dataMose._checkLayer))
        //    {
        //        dataMose._target.position = hitInfo.point;
        //    }
        //}


    }
}
