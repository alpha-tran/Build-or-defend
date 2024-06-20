using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillsR : MonoBehaviour
{
    [SerializeField] private GameObject _rangeObject;
    [SerializeField] private DataMose dataMose;
    [SerializeField] private DeploySkills Skills;
    private bool _isActive = true;

    private Vector3 _positionSkill;
    public void OnBeginDrag()
    {
        print("OnBeginDrag");
        _isActive = true;
        _rangeObject.SetActive(true);

    } 
    public void OnDrag()
    {
        if (_isActive)
        {
            UpdateRangeObjectPosition();
        }
        Debug.Log(_rangeObject.activeSelf);
    }

    public void OnEndDrag()
    {
        
        _isActive = false;
        _rangeObject.SetActive(false);
        Skills.DeplopSkillR(_positionSkill);
        Debug.Log("End drag");
    }

    private void UpdateRangeObjectPosition()
    {
        Vector2 mousePosition = dataMose.ActionMousePosition.action.ReadValue<Vector2>();
        Ray aimingRay = dataMose.Camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(aimingRay, out var hitInfo, dataMose.MaxDistance, dataMose.CheckLayer))
        {
            Vector3 positionDisplay = hitInfo.point;
            positionDisplay.y = 5f;
            _rangeObject.transform.position = positionDisplay;
            _positionSkill = positionDisplay;
        }
    }

}


