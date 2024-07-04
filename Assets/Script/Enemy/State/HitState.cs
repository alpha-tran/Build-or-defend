using System.Collections;
using UnityEngine;

public class HitState : StateBase
{
    protected override void OnEnter()
    {
        _enemy._enemyAgent.enabled = false;
    }

    protected override void OnExit()
    {
        _enemy._enemyAgent.enabled = true;
    }

  
}
