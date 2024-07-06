using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTheTower : MonoBehaviour
{
    [SerializeField] private GameObject _PrefabSkill;

    public void Begin(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            Vector3 spawnPosition = hit.point;
            Instantiate(_PrefabSkill, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Raycast did not hit any ground surface.");
        }
    }
}
