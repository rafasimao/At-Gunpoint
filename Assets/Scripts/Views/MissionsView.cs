using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MissionsView : MonoBehaviour 
{
	public Image MissionsImage;
	public Text MissionsTitle;
	public Text CoinText;

	public MissionView[] Missions;
	public bool CompleteIt;

	void OnEnable ()
	{
		UpdateMissionsInfo();
	}

	void UpdateMissionsInfo ()
	{
		MissionsImage.sprite = GameController.Instance.Missions.ActiveSetSprite;
		MissionsTitle.text = GameController.Instance.Missions.ActiveSetName;

		CoinText.text = ""+GameController.Instance.Missions.ActiveSetReward;
		ShowMissions();

		if (CompleteIt)
		{
			GameController.Instance.Missions.CompleteMissions();
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
