using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour 
{

	public bool IsTimeLimited;
	public float TotalTime, BlinkTime, BetweenBlinksTime;
	public Behaviour TargetBehaviour;
	public GameObject TargetGameObject;
	float _Timer;

	void OnEnable ()
	{
		_Timer = TotalTime;
		Invoke("Blink", BetweenBlinksTime);
	}

	void Blink ()
	{
		SetTargets(false);
		Invoke("Unblink", BlinkTime);
	}

	void Unblink ()
	{
		SetTargets(true);
		if (IsTimeLimited)
		{
			_Timer -= BetweenBlinksTime+BlinkTime;
			if (_Timer <= 0)
				return; // break the chain of blinks
		}

		Invoke("Blink", BetweenBlinksTime);
	}

	void SetTargets (bool active)
	{
		if (TargetBehaviour != null) TargetBehaviour.enabled = active;
		if (TargetGameObject != null) TargetGameObject.SetActive(active);
	}

}
