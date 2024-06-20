using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class DataMose 
{
    public InputActionReference ActionMousePosition;
    public Camera Camera;
    public float MaxDistance;
    public LayerMask CheckLayer;

    public Vector2 MousePosition => ActionMousePosition.action.ReadValue<Vector2>();
}
