using System.Collections;
using UnityEngine;

public class HitState : StateBase
{
    private float _hitRecoveryTime = 1.5f; // Example recovery time

    protected override void OnEnter()
    {
        _enemy._enemyAgent.enabled = false;
        _enemy.StartCoroutine(HitRecoveryCoroutine());
    }

    public override void Execute()
    {
    }

    protected override void OnExit()
    {
        _enemy._enemyAgent.enabled = true;
    }

    private IEnumerator HitRecoveryCoroutine()
    {
        yield return new WaitForSeconds(_hitRecoveryTime);

        if (_enemy != null && _enemy.PreviousState != null)
        {
            _enemy.ChangeState(_enemy.PreviousState.GetType().Name);
        }
    }
}
