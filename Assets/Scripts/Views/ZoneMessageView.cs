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
		ZoneText.text = "Zone "+n;
		ZoneTextBack.text = "Zone "+n;

		gameObject.SetActive(true);

		_Timer = 0f;
	}
}
