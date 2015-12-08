using UnityEngine;
using System.Collections;

[System.Serializable]
public class RunDescriptor
{
	public GameObject Base;
	public MissionsFamilySetDescriptor Missions;
	public CharacterDescriptor[] Characters;
	public ZoneDescriptor[] Zones;

	public BossDescriptor Boss;
}
