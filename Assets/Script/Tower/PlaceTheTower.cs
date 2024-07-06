using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTheTower : MonoBehaviour
{
    [SerializeField] private GameObject _PrefabSkill;
    [SerializeField] private float _heightSkill;
    public void Begin(Vector3 position)
    {
        position.y = _heightSkill;
        Instantiate(_PrefabSkill, position, Quaternion.identity);
    }
}
