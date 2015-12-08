using UnityEngine;
using System.Collections;

public class MissionsFamilySetDescriptor : ScriptableObject
{
	[SerializeField]
	int _Counter =0;

	public MissionsSetDescriptor[] Sets;

	public bool IsCompleted { get { return !(_Counter<Sets.Length); } }

	public void CompleteMissionSet ()
	{
		_Counter++;
	}

}
