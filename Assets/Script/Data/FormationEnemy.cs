using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "New Formation", menuName = "Formation/Enemy")]
internal class FormationEnemy : ScriptableObject
{
    public NavMeshAgent _enemyNav;
    public int count;
    public float delay;
    public FormationGeneral formation;
    public GameObject enemyPrefab;
    public float damage;
    public float attackSpeed;
    public FormationHealth healthEnemy;

}

