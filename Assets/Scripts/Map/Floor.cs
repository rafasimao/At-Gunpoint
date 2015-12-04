using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour 
{

	public MapController Map;

	bool _Triggered;

	Vector3 _InitialPosition;

	void Start ()
	{
		_InitialPosition = transform.position;
	}

	public void Reset ()
	{
		transform.position = _InitialPosition;
		_Triggered = false;
	}

	void OnTriggerEnter (Collider other) 
	{
		if (!_Triggered && other.tag.Equals("Player"))
		{
			Map.OnFloorTriggered(this);
			_Triggered = true;
		}
	}

	public void UpdateToNewFloor (float offset)
	{
		Vector3 pos = transform.position;
		transform.position = new Vector3(pos.x+offset, pos.y, pos.z);
		// Reload trigger
		_Triggered = false;
	}
}
