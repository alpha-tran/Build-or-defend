using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeploySkills : MonoBehaviour
{
    [SerializeField] private FormationSkill[] formationSkill;
    [SerializeField] private InputActionReference _inputClick;
    [SerializeField] private GameObject _rangeObject;
    [SerializeField] private float _heightSkill;

    [SerializeField] private DataMose dataMose;
    [SerializeField] private GameObject Prefab;

    void Start()
    {

    }

    void Update()
    {

        DisplayRange();

    }


    private void DisplayRange() // hiển thị sử dụng chiêu thức
    {
        bool skillActive = false;
        for (int i = 0; i < formationSkill.Length; i++)
        {
            if (formationSkill[i].inputSkill.action.IsPressed())
            {
                var mousePosition = dataMose._actionMousePosition.action.ReadValue<Vector2>(); // lấy vị trí của cho chuột
                skillActive = true;

                Ray aimingRay = dataMose._camera.ScreenPointToRay(mousePosition); // Raycat theo vị trí lấy đc
                if (Physics.Raycast(aimingRay, out var hitInfo, dataMose._maxDistance, dataMose._checkLayer))
                {

                    Display(hitInfo.point);

                    if (formationSkill[i].formation.Type == 3)
                    {
                        updatePosition();
                    }
                }
                break;

            }

        }
        _rangeObject.SetActive(skillActive);


    }

    private void Display(Vector3 position)
    {
        Vector3 positionDisplay = position; // phải tạo một biến để giữ giá trị , 
        positionDisplay.y = 2f; // không gán trực tiếp cho transform.position.y vì transform.position là thuộc tính chỉ đọc trong Unity
        _rangeObject.transform.position = positionDisplay;// gán vị trí vào gameObject phụ trách hiển thị
    }

    private void updatePosition()
    {
        if (_inputClick.action.triggered)
        {
            StartCoroutine(DelaySkill(_rangeObject.transform.position));
        }
    }


    private IEnumerator DelaySkill(Vector3 position)
    {

        for (int i = 0; i < formationSkill.Length; i++)
        {

            for (int j = 0; j < formationSkill[i].formation.Type; i++)
            {

                if (formationSkill[i].formation.Type == 3)
                {
                    DeplopSkillR(position);
                    yield return new WaitForSeconds(formationSkill[i].timeRetrieval);
                }
                //else if (formationSkill[i].formation.Type == 2)
                //{

                //}
                //else if (formationSkill[i].formation.Type == 1)
                //{

                //}
            }

        }

    }

    public void DeplopSkillR(Vector3 mousePosition)
    {


        for (int i = 0; i < formationSkill.Length; i++)
        {

            if (formationSkill[i].formation.Type == 1)
            {
                Vector3 positionSkill = new Vector3(mousePosition.x, _heightSkill, mousePosition.z);
                Instantiate(Prefab, positionSkill, Quaternion.identity);

            }
        }

    }


}

