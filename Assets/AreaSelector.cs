using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AreaSelector : MonoBehaviour
{
    [SerializeField] private Transform _rangeIndicator;
	[SerializeField] private InputActionReference _inputMoseCancel;
    [SerializeField] private DataMose _dataMose;

	public UnityEvent<Vector3> OnAccept;

	private Vector3 _center;

	private bool _onCencal = false;
	private bool _onDestroy = false;
	private void Start()
	{
        enabled = false;
		
    }

    [ContextMenu("Begin")]
	public void Begin()
    {
			print("Begin");

        _rangeIndicator.gameObject.SetActive(true);
        enabled = true;
    }

	public void Update()
	{
		var mousePosition = _dataMose.MousePosition;
		var ray = _dataMose.Camera.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out var hitInfo, _dataMose.MaxDistance, _dataMose.CheckLayer))
		{
			_center = hitInfo.point;
			_center.y = 2f;
			_rangeIndicator.position = _center;
		}

		if (Input.anyKeyDown || _inputMoseCancel.action.triggered)
		{
			_onCencal = true;

        }
	}
	[ContextMenu("Accept")]
	public void Accept()
    {
		Stop();
		if(_onCencal == false)
		{
            if (_onDestroy == false)
            {
                print("Accept");
                OnAccept.Invoke(_center);
            }
                _onDestroy = false;

        }
		
    }

	[ContextMenu("Cancel")]
	public void Cancel()
    {
		if(_onCencal == true)
		{
            print("on");
            Stop();
			_onCencal = false;
            _onDestroy = true;
        }


    }

    private void Stop()
    {
		enabled = false;
		_rangeIndicator.gameObject.SetActive(false);
	}



}
