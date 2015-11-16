using UnityEngine;
using System.Collections;

[System.Serializable]
public class WarDescriptor
{
	public RunDescriptor Run1, Run2;
	// public Quest Quests;

	public bool IsBlocked;

	public void Unblock ()
	{
		IsBlocked = false;
	}
}
