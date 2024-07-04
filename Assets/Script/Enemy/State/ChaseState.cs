using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateBase
{
    private bool _isAttacking;

    protected override void OnEnter()
    {
        _isAttacking = false;

        if (!_enemy._enemyAgent.isOnNavMesh)
        {
            // Di chuyển NavMeshAgent đến một vị trí hợp lệ trên NavMesh
            NavMeshHit hit;
            if (NavMesh.SamplePosition(_enemy.transform.position, out hit, 1.0f, NavMesh.AllAreas))
            {
                _enemy.transform.position = hit.position;
                _enemy._enemyAgent.Warp(hit.position);
            }
            else
            {
                Debug.LogError("NavMeshAgent is not on the NavMesh and could not find a valid position!");
                _enemy.ChangeState("MoveToTargetState");
                return;
            }
        }

        _enemy._enemyAgent.enabled = true;
    }

    public override void Execute()
    {
        _enemy.UpdateTargetList();
        _enemy.FindNearestTarget();

        if (_enemy.CurrentTarget == null)
        {
            _enemy.ChangeState("MoveToTargetState");
            return;
        }

        if (_enemy.ShouldAttackCondition() && !_isAttacking)
        {
            _enemy._enemyAgent.SetDestination(_enemy.transform.position);
            _enemy.ChangeState("AttackState");
            _isAttacking = true;
        }
        else
        {
            _enemy._enemyAgent.SetDestination(_enemy.CurrentTarget.transform.position);
        }
    }

    protected override void OnExit()
    {
        _isAttacking = false;
    }
}
