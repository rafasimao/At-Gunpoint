using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionData 
{
	public int Counter;

	public MissionData ()
	{
		Counter = 0;
	}

	public void FetchData (Mission mission)
	{
		Counter = mission.Counter;
	}

}
