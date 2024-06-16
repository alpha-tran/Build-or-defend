using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Thông tin quái")]
    [SerializeField] private FormationEnemy[] enemyFor;

    [SerializeField] private Transform _target;
    [SerializeField] private float _enemyInterval;

    [Header("Sinh ra quái")]
    [SerializeField] protected Transform _insTransform; // vị trí sinh ra
    [SerializeField] protected GameObject _prefabEnemy; // model

  


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        for(int i = 0; i < enemyFor.Length; i++)
        {
            yield return new WaitForSeconds(enemyFor[i].delay);
            SpawnFormation(i);
        }    
    }

    private void SpawnFormation(int index)
    {
        FormationEnemy form = enemyFor[index];
        for(int i = 0; i< form.count; i++)
        {
            SpawnEnemy(form, i);
        }    
    }

    private void SpawnEnemy(FormationEnemy form, int i)
    {
        GameObject enemy = Instantiate(form.Formation.Prefab);
        //FlyAgent agent = enemy.GetComponent<FlyAgent>();
        //agent.route = form.route;
        //agent.formationDistance = form.formationDistance * index;
        //agent.speed = form.speed;
        //var health = enemy.GetComponent<Health>();
        //health.onDead.AddListener(() => {
        //    scoring.AddScore(1);
        //});
    }

}
