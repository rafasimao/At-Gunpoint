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

	public GameObject AllCompletedGO;

	void OnEnable ()
	{
		UpdateMissionsInfo();
	}

	void UpdateMissionsInfo ()
	{

		ShowMissionsInfo();

		if (CompleteIt)
		{
			GameController.Instance.Missions.CompleteMissions();
			Invoke("ShowMissionsInfo",2.5f);
		}
	}

	void ShowMissionsInfo ()
	{
		if (GameController.Instance.Missions.IsMissionsFamilyCompleted)
		{
			AllCompletedGO.SetActive(true);
			ShowMissionsFamily();
		}
		else
		{
			AllCompletedGO.SetActive(false);
			ShowMissionsSet();
		}
	}

	void ShowMissionsFamily ()
	{
		MissionsImage.sprite = GameController.Instance.Missions.ActiveFamilySprite;
		MissionsTitle.text = GameController.Instance.Missions.ActiveFamilyName;
		CoinText.text = "";
	}

	void ShowMissionsSet ()
	{
		MissionsImage.sprite = GameController.Instance.Missions.ActiveSetSprite;
		MissionsTitle.text = GameController.Instance.Missions.ActiveSetName;
		
		CoinText.text = ""+GameController.Instance.Missions.ActiveSetReward;

		ShowMissions();
	}

	void ShowMissions ()
	{
		List<Mission> missions = GameController.Instance.Missions.Missions;
		int count = (missions!=null) ? missions.Count : 0 ;
		for (int i=0; i<Missions.Length; i++)
			Missions[i].UpdateInfo((i<count) ? missions[i] : null);
	}

	void OnDisable ()
	{
		CancelInvoke();
	}
}
