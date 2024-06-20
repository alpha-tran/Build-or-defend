using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AreaSelector : MonoBehaviour
{
    [SerializeField] private Transform _rangeIndicator;
	[SerializeField] private DataMose _dataMose;

	public UnityEvent<Vector3> OnAccept;

	private Vector3 _center;

	private void Start() => enabled = false;

	[ContextMenu("Begin")]
	public void Begin()
    {
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
			_rangeIndicator.position = _center;
		}
	}

	[ContextMenu("Accept")]
	public void Accept()
    {
		Stop();
		OnAccept.Invoke(_center);
	}

	[ContextMenu("Cancel")]
	public void Cancel()
    {
        Stop();
    }

    private void Stop()
    {
		enabled = false;
		_rangeIndicator.gameObject.SetActive(false);
	}
}
