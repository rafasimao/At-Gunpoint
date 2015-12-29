using UnityEngine;
using System.Collections;

public class MissionsFamilySetDescriptor : ScriptableObject
{
	[SerializeField]
	int _Counter =0;
	public int Counter { get { return _Counter; } }

	public MissionsSetDescriptor[] Sets;

	public MissionsSetDescriptor CurrentSet { get { return (_Counter<Sets.Length) ? Sets[_Counter] : null; } }
	public bool IsCompleted { get { return !(_Counter<Sets.Length); } }

	public void CompleteMissionSet ()
	{
		if (_Counter+1 < Sets.Length)
			_Counter++;
	}

	public void LoadData (MissionsFamilySetData data)
	{
		_Counter = data.Counter;
		for (int i=0; i<Sets.Length; i++)
			Sets[i].LoadData(data.MissionsSets[i]);
	}

}
