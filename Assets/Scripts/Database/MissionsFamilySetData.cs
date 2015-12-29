using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MissionsFamilySetData
{
	public int Counter;
	public List<MissionsSetData> MissionsSets;

	public MissionsFamilySetData ()
	{
		Counter = 0;
		MissionsSets = new List<MissionsSetData>();
	}

	public void FetchData (MissionsFamilySetDescriptor missionsFamily)
	{
		Counter = missionsFamily.Counter;
		for (int i=0; i<missionsFamily.Sets.Length; i++)
		{
			MissionsSets.Add(new MissionsSetData());
			MissionsSets[i].FetchData(missionsFamily.Sets[i]);
		}
	}

}
