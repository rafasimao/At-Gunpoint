using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour 
{

	public MapController Map;

	void OnTriggerEnter (Collider other) 
	{
		if (other.tag.Equals("Player"))
		{
			Map.OnFloorTriggered(this);
		}
	}

	public void UpdateToNewFloor (float offset)
	{
		Vector3 pos = transform.position;
		transform.position = new Vector3(pos.x+offset, pos.y, pos.z);
	}
}
