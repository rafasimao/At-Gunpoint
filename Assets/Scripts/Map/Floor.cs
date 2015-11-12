using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour 
{

	public MapController Map;

	bool _Triggered;

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
