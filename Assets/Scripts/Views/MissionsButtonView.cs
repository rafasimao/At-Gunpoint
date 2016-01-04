using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionsButtonView : MonoBehaviour 
{
	public Image MissionImage;

	void OnEnable ()
	{
		UpdateImage();
	}

	public void UpdateImage ()
	{
		MissionImage.sprite = (GameController.Instance.Missions.IsMissionsFamilyCompleted) ?
			GameController.Instance.Missions.ActiveFamilySprite :
				GameController.Instance.Missions.ActiveSetSprite;
	}
}
