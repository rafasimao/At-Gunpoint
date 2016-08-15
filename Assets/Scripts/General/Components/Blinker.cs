using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour 
{

	public bool IsTimeLimited;
	public float TotalTime, BlinkTime, BetweenBlinksTime;
	public Behaviour TargetBehaviour;
	public GameObject TargetGameObject;
	//float _Timer;

	void OnEnable ()
	{
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
		Invoke("Blink", BetweenBlinksTime);
	}

	void SetTargets (bool active)
	{
		if (TargetBehaviour != null) TargetBehaviour.enabled = active;
		if (TargetGameObject != null) TargetGameObject.SetActive(active);
	}

}
