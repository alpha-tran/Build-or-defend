//using System.Collections;
//using UnityEngine;

//public class MoveToTargetState : IEnemyState
//{
//    private EnemyState _enemy;

//    public void Enter(EnemyState enemy)
//    {
//        _enemy = enemy;
//        _enemy.StartCoroutine(MoveToTarget());
//    }

//    public void Execute() { }

//    public void Exit()
//    {
//        _enemy.StopCoroutine(MoveToTarget());
//    }

//    private IEnumerator MoveToTarget()
//    {
//        while (true)
//        {
//            if (_enemy.CurrentTarget == null)
//            {
//                _enemy.ChangeState(new IdleState());
//                yield break;
//            }

//            float distance = Vector3.Distance(_enemy.CurrentTarget.position, _enemy.transform.position);
//            if (distance < _enemy.AttackDistance)
//            {
//                _enemy.ChangeState(new ActionAtTargetState());
//                yield break;
//            }
//            else
//            {
//                _enemy.EnemyAgent.SetDestination(_enemy.CurrentTarget.position);
//            }

//            yield return null;
//        }
//    }
//}
