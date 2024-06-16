using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class DataMose 
{
    public  InputActionReference _actionMousePosition;
    public  InputActionReference _actionMouseClick;
    public  Camera _camera;
    public  Transform _target;
    public  LayerMask _checkLayer;
    public  float _maxDistance;
}
