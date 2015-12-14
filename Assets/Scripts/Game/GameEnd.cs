using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour 
{

	public GameObject Missions;

	void OnEnable ()
	{
		PlayerTracer.EndRun();
		Missions.SetActive(true);
	}

	void OnDisable ()
	{
		Missions.SetActive(false);
	}
}
