using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyDeath : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rigid;

    public void OnDead()
    {
        _agent.enabled = false;
        _rigid.isKinematic = false;
        Destroy(gameObject,1f);
    }
}
