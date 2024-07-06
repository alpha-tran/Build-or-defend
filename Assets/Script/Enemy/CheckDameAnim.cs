using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDameAnim : MonoBehaviour
{
    private bool _check;
    internal bool Check => _check;

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
