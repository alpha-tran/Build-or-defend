using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDame : MonoBehaviour
{
    private bool _check;
    internal bool Check => _check;

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dame") && other.gameObject != null)
        {
           _check = true;
        }
    }

    public void ResetHit()
    {
        _check = false;
    }

}
