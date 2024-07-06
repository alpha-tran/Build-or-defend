using UnityEngine;

public class MoveToTargetState : StateBase
{
    protected override void OnEnter()
    {
        if (_enemy.CheckTransformTargetPosition())
        {
            _enemy._enemyAgent.enabled = true;
            _enemy._enemyAgent.SetDestination(_enemy._transformTarget.transform.position);
        }
        else
        {
        }
    }

    public override void Execute()
    {
        _enemy.UpdateTargetList();
        _enemy.FindNearestTarget();

        if (_enemy.HasTargets())
        {
            _enemy.ChangeState("ChaseState");
            return;
        }

        if (_enemy._enemyAgent.remainingDistance < 0.5f)
        {
        }
    }

    protected override void OnExit()
    {
    }
}
