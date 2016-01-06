using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MissionsSetData
{
	public List<MissionData> Missions;

	public MissionsSetData ()
	{
		Missions = new List<MissionData>();
	}

	public void FetchData (MissionsSetDescriptor missionsSet)
	{
		for (int i=0; i<missionsSet.Missions.Count; i++)
		{
			Missions.Add(new MissionData());
			Missions[i].FetchData(missionsSet.Missions[i]);
		}
	}

}
