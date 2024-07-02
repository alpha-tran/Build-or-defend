//using System.Collections;
//using UnityEngine;

//public class IdleState : MonoBehaviour
//{
//    private EnemyState _enemy;
//    private IEnemyState _a;
//    public void Enter(EnemyState enemy)
//    {
//        _enemy = enemy;
//        _enemy.StartCoroutine(SearchForTargets());
//    }

//    public void Execute() { }

//    public void Exit()
//    {
//        _enemy.StopCoroutine(SearchForTargets());
//    }

//    private IEnumerator SearchForTargets()
//    {
//        while (true)
//        {
//            _enemy.UpdateTargetList();
//            _enemy.FindNearestTarget();

//            if (_enemy.CurrentTarget != null)
//            {
//                _enemy.ChangeState(new MoveToTargetState());
//                yield break;
//            }

//            yield return new WaitForSeconds(_enemy.SearchInterval);
//        }
//    }
//}
