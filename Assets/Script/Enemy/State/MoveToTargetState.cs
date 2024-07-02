using UnityEngine;

public class MoveToTargetState : StateBase
{
    protected override void OnEnter()
    {
        _enemy._enemyAgent.enabled = true;
        _enemy._enemyAgent.SetDestination(_enemy._transformTarget.transform.position);
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
            // Logic for when enemy reaches the final target can be implemented here
        }
    }

    protected override void OnExit()
    {
        Debug.Log("Exiting MoveToTarget State");
    }
}
