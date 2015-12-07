using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsView : MonoBehaviour 
{

	public MissionView[] Missions;
	public bool CompleteIt;

	void OnEnable ()
	{
		UpdateMissionsInfo();
	}

	void UpdateMissionsInfo ()
	{
		ShowMissions();

		if (CompleteIt)
		{
			GameController.Instance.Missions.CompleteQuests();
			Invoke("ShowMissions",2.5f);
		}
	}

	void ShowMissions ()
	{
		List<Mission> missions = GameController.Instance.Missions.ActiveMissions;
		for (int i=0; i<Missions.Length; i++)
			Missions[i].UpdateInfo((i<missions.Count) ? missions[i] : null);
	}

	void OnDisable ()
	{
		CancelInvoke();
	}
}
