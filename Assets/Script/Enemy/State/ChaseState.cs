using UnityEngine;

public class ChaseState : StateBase
{
    private bool _isAttacking;

    protected override void OnEnter()
    {
        _isAttacking = false;
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
