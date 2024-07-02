using UnityEngine;

public abstract class StateBase
{
    protected EnemyState _enemy;

    public void Enter(EnemyState enemy)
    {
        _enemy = enemy;
        OnEnter();
    }

    public virtual void Execute() { }

    public void Exit()
    {
        OnExit();
    }

    protected abstract void OnEnter();
    protected abstract void OnExit();
}
