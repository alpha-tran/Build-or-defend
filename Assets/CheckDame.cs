using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDame : MonoBehaviour
{
    public bool _check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dame"))
        {
           _check = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dame"))
        {
            _check = false;

        }
    }
}
