using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoneMessageView : MonoBehaviour
{
	public Text ZoneText, ZoneTextBack;

	public float ShowTime;
	float _Timer;

	void Update ()
	{
		_Timer+=Time.deltaTime;
		if (_Timer > ShowTime)
			gameObject.SetActive(false);
	}

	public void ShowZoneMessage (int n)
	{
		Show("ZONE "+n);
	}

	public void ShowBossZoneMessage ()
	{
		Show("BOSS");
	}

	void Show (string message)
	{
		ZoneText.text = message;
		ZoneTextBack.text = message;
		
		gameObject.SetActive(true);
		
		_Timer = 0f;
	}
}
