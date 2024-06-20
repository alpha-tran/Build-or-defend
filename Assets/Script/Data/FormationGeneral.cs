using UnityEngine;

[CreateAssetMenu(fileName = "New Formation", menuName = "Formation/FormationGeneral")]
public class FormationGeneral : ScriptableObject
{
    public string name;
    public string description;
    public int range;
    public int Type;
}
