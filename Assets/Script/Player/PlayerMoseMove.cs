using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoseMove : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private Transform _transformTarget;

    private Vector3 _velocity;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

 

    private void Move()
    {
        _playerAgent.SetDestination(_transformTarget.position);
    }
}
