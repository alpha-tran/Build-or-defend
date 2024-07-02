//using System.Collections;
//using UnityEngine;

//public class ActionAtTargetState : IEnemyState
//{
//    private EnemyState _enemy;

//    public void Enter(EnemyState enemy)
//    {
//        _enemy = enemy;
//        _enemy.StartCoroutine(PerformAction());
//    }

//    public void Execute() { }

//    public void Exit()
//    {
//        _enemy.StopCoroutine(PerformAction());
//    }

//    private IEnumerator PerformAction()
//    {
//        Debug.Log("Performing action at target");
//        yield return new WaitForSeconds(1f);

//        _enemy.ChangeState(new IdleState());
//    }
//}
