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
    [SerializeField] private float _enemyInterval;

    [Header("Thông tin quái")]
    [SerializeField] private FormationEnemy[] enemyFor;



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
            SpawnEnemy(form);
        }    
    }

    private void SpawnEnemy(FormationEnemy form)
    {
        GameObject enemy = Instantiate(form.enemyPrefab, _insTransform.position, _insTransform.rotation);
        
    }

}
