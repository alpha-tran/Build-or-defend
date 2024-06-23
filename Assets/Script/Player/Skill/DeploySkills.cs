using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DeploySkills : MonoBehaviour
{
    [SerializeField] private FormationSkill[] formationSkill;
    [SerializeField] private InputActionReference _inputClick;
    [SerializeField] private GameObject _rangeObject;
    [SerializeField] private float _heightSkill;
    [SerializeField] private DataMose dataMose;
    [SerializeField] private GameObject Prefab;


    private Vector3 _position;
    private bool _isSkillReady = true;

    void Start()
    {
        StartCoroutine(ManageSkills());
    }

    void Update()
    {
        DisplayRange();
    }

    private void DisplayRange()
    {
        bool skillActive = false;

        for (int i = 0; i < formationSkill.Length; i++)
        {
            if (formationSkill[i].inputSkill.action.IsPressed())
            {
                var mousePosition = dataMose.ActionMousePosition.action.ReadValue<Vector2>();
                skillActive = true;

                Ray aimingRay = dataMose.Camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(aimingRay, out var hitInfo, dataMose.MaxDistance, dataMose.CheckLayer))
                {
                    Display(hitInfo.point);
                    _position = hitInfo.point;

                    if (_inputClick.action.triggered && _isSkillReady)
                    {
                        _isSkillReady = false;
                        StartCoroutine(DelaySkill(formationSkill[i]));
                    }
                }
            }
        }

        _rangeObject.SetActive(skillActive);
    }

    private void Display(Vector3 position)
    {
        Vector3 positionDisplay = position;
        positionDisplay.y = 2f; // Điều chỉnh chiều cao nếu cần thiết
        _rangeObject.transform.position = positionDisplay;
    }

    private IEnumerator ManageSkills()
    {
        while (true)
        {
         

            yield return new WaitUntil(() => _inputClick.action.triggered);
        }
    }

    private IEnumerator DelaySkill(FormationSkill skill)
    {
        yield return new WaitForSeconds(skill.timeRetrieval);

        DeplopSkillR(_position);

        _isSkillReady = true;
    }

    public void DeplopSkillR(Vector3 position)
    {
        Vector3 positionSkill = new Vector3(position.x, _heightSkill, position.z);
        Instantiate(Prefab, positionSkill, Quaternion.identity);
        

    
    }



}
