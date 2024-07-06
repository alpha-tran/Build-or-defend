using UnityEngine;

public class AttackState : StateBase
{
    protected override void OnEnter()
    {
        _enemy._enemyAgent.enabled = false;
    }

    public override void Execute()
    {
        float distance = Vector3.Distance(_enemy.CurrentTarget.transform.position, _enemy.transform.position);
        if (distance > _enemy._attackDistance)
        {
            _enemy.ChangeState("ChaseState");
        }
   
    }

    protected override void OnExit()
    {
    }
}
