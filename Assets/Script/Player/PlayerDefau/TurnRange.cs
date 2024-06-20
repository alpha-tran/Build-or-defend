using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnRange : MonoBehaviour
{
    [SerializeField] private InputActionReference _InputRange;
    [SerializeField] private GameObject _RangeObject; // game object tầm đánh

    void Update()
    {
        RangeOn();
    }


    private void RangeOn()
    {

        if (_InputRange.action.IsPressed())
        {
            _RangeObject.SetActive(true);
        }
        else
        {
            _RangeObject.SetActive(false);
        }

    }
}
