using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    public NavMeshAgent _enemyAgent;
    public GameObject _transformTarget;
    public float _attackDistance;


    private List<GameObject> _targets = new List<GameObject>();
    private GameObject _currentTarget;
    private StateBase _currentState;
    private StateBase _previousState; // Add this field to store previous state

    internal GameObject CurrentTarget => _currentTarget;

    private Health _health;

    private void Start()
    {
        _enemyAgent = _enemyAgent ?? GetComponent<NavMeshAgent>();
        _health = GetComponent<Health>();

        if (_transformTarget == null)
        {
            return;
        }

        ChangeState("MoveToTargetState");
    }

    private void Update()
    {
        _currentState?.Execute();
    }

    public void ChangeState(string newStateName)
    {
        StateBase newState = CreateState(newStateName);

        if (newState == null)
        {
            return;
        }

        _previousState = _currentState;
        _currentState?.Exit(); 
        _currentState = newState;
        _currentState.Enter(this); 
    }

    public StateBase PreviousState => _previousState;

    private StateBase CreateState(string stateName)
    {
        switch (stateName)
        {
            case "MoveToTargetState":
                return new MoveToTargetState();
            case "ChaseState":
                return new ChaseState();
            case "AttackState":
                return new AttackState();
            case "HitState":
                return new HitState();
            default:
                return null;
        }
    }

    public bool ShouldAttackCondition()
    {
        if (_currentTarget == null)
        {
            return false; // Don't attack if no target
        }

        float distance = Vector3.Distance(_currentTarget.transform.position, transform.position);
        return distance < _attackDistance;
    }

    public bool HasTargets()
    {
        return _targets.Count > 0;
    }

    
 

    public void UpdateTargetList()
    {
        _targets.RemoveAll(target => target == null);
    }

    public void FindNearestTarget()
    {
        float minDistance = float.MaxValue;
        _currentTarget = null;
        foreach (var target in _targets)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _currentTarget = target;
            }
        }
        if (_currentTarget == null)
        {
            _currentTarget = _transformTarget;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower") || other.CompareTag("Player"))
        {
            _targets.Add(other.gameObject);
        }

    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower") || other.CompareTag("Player"))
        {
            _targets.Remove(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }



    public bool CheckDame()
    {
        var checkDameComponent = GetComponent<CheckDame>();
        print(checkDameComponent._check);
        if (checkDameComponent._check == true)
        {

            return true;

        }
        return false;
    }

    public void HandleDamageTaken()
    {
        if (CheckDame())
        {
            ChangeState("HitState");
        }
    }


}
