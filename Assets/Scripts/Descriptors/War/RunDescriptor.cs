﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class RunDescriptor : ScriptableObject
{
	[SerializeField]
	int _CheckpointZone = 0;
	public int CheckpointZone { get { return _CheckpointZone; } }

	public GameObject Base;
	public MissionsFamilySetDescriptor Missions;
	public CharacterDescriptor[] Characters;
	public ZoneDescriptor[] Zones;
	public BossDescriptor Boss;

	public void SaveCheckpoint (int zone)
	{
		if (zone>-1 && zone<Zones.Length)
			_CheckpointZone=zone;
	}

	public void ResetCheckpoint ()
	{
		_CheckpointZone = 0;
	}
}
