using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "New Formation", menuName = "Formation/Skill")]
public class FormationSkill : ScriptableObject
{

    public float timeRetrieval;
    public InputActionReference inputSkill;
    public FormationGeneral formation;
    public float count;

}
