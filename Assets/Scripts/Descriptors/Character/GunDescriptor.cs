using UnityEngine;
using System.Collections;

[System.Serializable]
public class GunDescriptor
{
	public string Name;
	public BulletsController.BulletTypes BulletType;
	public float BulletSpeed;
	public GunLevel[] Levels;

	public int NumberOfLevels { get { return Levels.Length; } }
	public GunLevel LastLevel { get { return Levels[NumberOfLevels-1]; } }

}
