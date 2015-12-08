using UnityEngine;
using System.Collections;

public class MissionsFamilySetDescriptor : ScriptableObject
{
	[SerializeField]
	int _Counter =0;

	public MissionsSetDescriptor[] Sets;

	public MissionsSetDescriptor CurrentSet { get { return (_Counter<Sets.Length) ? Sets[_Counter] : null; } }
	public bool IsCompleted { get { return !(_Counter<Sets.Length); } }

	public void CompleteMissionSet ()
	{
		_Counter++;
	}

}
