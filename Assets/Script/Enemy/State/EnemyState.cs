using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    public NavMeshAgent _enemyAgent;
    public GameObject _transformTarget;
    public float _attackDistance;
    public CheckDameAnim CheckDamage;

    private List<GameObject> _targets = new List<GameObject>();
    private GameObject _currentTarget;
    private StateBase _currentState;
    private StateBase _previousState;
    private bool _isHitState = false;
    public StateBase PreviousState => _previousState;
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
        HandleDamageTaken();
        if (_currentTarget != null)
        {
            RotateTowards(_currentTarget.transform.position);
        }
    }

    public void ChangeState(string newStateName)
    {
        if (newStateName == "HitState")
        {
            _isHitState = true;
        }

        StateBase newState = CreateState(newStateName);

        if (newState == null)
        {
            return;
        }

        _previousState = _currentState;
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter(this);

        if (_isHitState && newStateName != "HitState")
        {
            _isHitState = false;
        }
    }

   

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
            return false;
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

    public Transform FindNearestTarget()
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

        return _currentTarget?.transform;
    }

    public void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
        return CheckDamage.Check;
    }

    public void HandleDamageTaken()
    {
        if (CheckDame() && !_isHitState)
        {
            ChangeState("HitState");
        }
    }

    public void OnHitAnimationEnd()
    {
        if (_isHitState && _previousState != null)
        {
            ChangeState(_previousState.GetType().Name);
        }
    }

    public bool CheckTransformTargetPosition()
    {
        return _transformTarget != null && _transformTarget.transform.position != null;
    }


}
