using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeploySkills : MonoBehaviour
{
    [SerializeField] private FormationSkill[] formationSkill;
    [SerializeField] private InputActionReference _inputSkill;
    [SerializeField] private InputActionReference _inputClick;
    [SerializeField] private GameObject _rangeObject;
    [SerializeField] private float _heightSkill;

    [SerializeField] private DataMose dataMose;
    [SerializeField] public bool skillActivated = false;



    void Start()
    {

    }

    void Update()
    {
        DisplayRange();
    }


    private void DisplayRange() // hiển thị sử dụng chiêu thức
    {
        if (_inputSkill.action.IsPressed())
        {
            var mousePosition = dataMose._actionMousePosition.action.ReadValue<Vector2>(); // lấy vị trí của cho chuột
            _rangeObject.SetActive(true);

            Ray aimingRay = dataMose._camera.ScreenPointToRay(mousePosition); // Raycat theo vị trí lấy đc
            if (Physics.Raycast(aimingRay, out var hitInfo, dataMose._maxDistance, dataMose._checkLayer))
            {
                Display(hitInfo.point);

                StartCoroutine(DelaySkill(_rangeObject.transform.position));

            }
        }
        else
        {
            _rangeObject.SetActive(false);
        }
    }

    private void Display(Vector3 position)
    {
        Vector3 positionDisplay = position; // phải tạo một biến để giữ giá trị , 
        positionDisplay.y = 2f; // không gán trực tiếp cho transform.position.y vì transform.position là thuộc tính chỉ đọc trong Unity
        _rangeObject.transform.position = positionDisplay;// gán vị trí vào gameObject phụ trách hiển thị
    }


    private IEnumerator DelaySkill(Vector3 position)
    {
        for (int i = 0; i < formationSkill.Length; i++)
        {
            DeplopSkill(position);
            yield return new WaitForSeconds(formationSkill[i].delay);
        }

    }

    private void DeplopSkill(Vector3 mousePosition)
    {
        if (_inputClick.action.triggered)
        {
            for (int i = 0; i< formationSkill.Length;i++)
            {
                Vector3 positionSkill = new Vector3(mousePosition.x, _heightSkill, mousePosition.z);
                Instantiate(formationSkill[i].Formation.Prefab, positionSkill, Quaternion.identity);
            }

        }
    }    

   
}

