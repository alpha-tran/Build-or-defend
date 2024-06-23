using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private GameObject _transformTarget;
    [SerializeField] private float _attackDistance;

    private List<GameObject> _targets = new ();
    private GameObject _currentTarget;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tower") || other.CompareTag("Player"))
        {
            _targets.Add(other.gameObject);
            print("vo");
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower") || other.CompareTag("Player"))
        {
            _targets.Remove(other.gameObject);
            print(other.gameObject);

        }
    }

    void Update()
    {
        UpdateTargetList();
        FindNearestTarget();
        Move();
    }

    private void UpdateTargetList()
    {
        for (int i = _targets.Count - 1; i >= 0; i--)
        {
            if (_targets[i] == null)
            {
                _targets.RemoveAt(i);
            }
        }
    }

    private void FindNearestTarget()
    {
        float minDistance = float.MaxValue;
        _currentTarget = null;
        for (int i = 0; i < _targets.Count; i++)
        {
            var distance = Vector3.Distance(_targets[i].transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _currentTarget = _targets[i];
            }
        }
        if (_currentTarget == null)
        {
            _currentTarget = _transformTarget;
        }
    }

    private void Move()
    {
        if (_currentTarget == null) return;
        var distance = Vector3.Distance(_currentTarget.transform.position, transform.position);
        if (distance < _attackDistance)
        {
            _enemyAgent.enabled = false;
        }
        else
        {
            _enemyAgent.enabled = true;
            _enemyAgent.SetDestination(_currentTarget.transform.position);
        }

    }

    private void OnDrawGizmos()
    {
        if (transform.position != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _attackDistance);
        }
    }

}
