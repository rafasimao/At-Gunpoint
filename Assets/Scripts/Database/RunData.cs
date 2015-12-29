using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RunData
{
	public int CheckpointZone;
	public MissionsFamilySetData MissionsFamilySet;
	public List<CharacterData> Characters;

	public RunData ()
	{
		CheckpointZone = 0;
		MissionsFamilySet = new MissionsFamilySetData();
		Characters = new List<CharacterData>();
	}

	public void FetchData (RunDescriptor run)
	{
		CheckpointZone = run.CheckpointZone;

		MissionsFamilySet.FetchData(run.Missions);

		for (int i=0; i<run.Characters.Length; i++)
		{
			Characters.Add(new CharacterData());
			Characters[i].FetchData(run.Characters[i]);
		}
	}

}
