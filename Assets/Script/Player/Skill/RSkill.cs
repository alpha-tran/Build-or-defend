using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RSkill : MonoBehaviour
{
    [SerializeField] private GameObject _PrefabSkill;
    [SerializeField] private float _heightSkill;
   
    public void Begin(Vector3 position)
	{
        position.y = _heightSkill;
        Instantiate(_PrefabSkill, position, Quaternion.identity);
    }


}
