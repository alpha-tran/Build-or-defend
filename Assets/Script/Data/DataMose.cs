using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class DataMose 
{
    public InputActionReference _actionMousePosition;
    public Camera _camera;
    public float _maxDistance;
    public LayerMask _checkLayer;
}
