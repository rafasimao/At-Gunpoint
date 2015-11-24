using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour
{

	public Collider[] CollidersOn, CollidersOff;
	public Behaviour[] BehavioursOn, BehavioursOff;

	public void Switch (bool isOn)
	{
		ActivateColliders(CollidersOn,isOn);
		ActivateColliders(CollidersOff,!isOn);

		ActivateBehaviours(BehavioursOn,isOn);
		ActivateBehaviours(BehavioursOff,!isOn);
	}

	void ActivateObjects (GameObject[] objs, bool isOn)
	{
		for (int i=0; i<objs.Length; i++)
			objs[i].SetActive(isOn);
	}

	void ActivateColliders (Collider[] colliders, bool isOn)
	{
		for (int i=0; i<colliders.Length; i++)
			colliders[i].enabled = isOn;
	}

	void ActivateBehaviours (Behaviour[] behaviours, bool isOn)
	{
		for (int i=0; i<behaviours.Length; i++)
			behaviours[i].enabled = isOn;
	}

}
