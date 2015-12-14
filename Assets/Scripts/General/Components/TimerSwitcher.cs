using UnityEngine;
using System.Collections;

public class TimerSwitcher : MonoBehaviour 
{

	public float FadeTime;
	public GameObject SwitchOn;

	void OnEnable ()
	{
		Invoke ("Disappear", FadeTime);
	}

	void Disappear ()
	{
		gameObject.SetActive(false);
		if (SwitchOn!=null)
			SwitchOn.SetActive(true);
	}

}
