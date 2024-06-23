using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Sinh ra quái")]
    [SerializeField] private Transform _insTransform; // vị trí sinh ra
    [SerializeField] private float _timeWaves;

    [Header("Thông tin quái")]
    [SerializeField] private FormationEnemy[] enemyFor;



    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(DelaySpawn());
    }


    private IEnumerator DelaySpawn()
    {
        for(int i = 0; i < enemyFor.Length; i++)
        {
            StartCoroutine(SpawnFormation(i));
            yield return new WaitForSeconds(_timeWaves);
        }    
    }

    private IEnumerator SpawnFormation(int index)
    {
        FormationEnemy form = enemyFor[index];
        for(int i = 0; i < form.count; i++)
        {
            SpawnEnemy(form);
            yield return new WaitForSeconds(form.delay);
        }
    }

    private void SpawnEnemy(FormationEnemy form)
    {
        GameObject enemy = Instantiate(form.enemyPrefab, _insTransform.position, _insTransform.rotation);
    }

}
