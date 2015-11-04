using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterDescriptor
{
	public string Name;
	public GameObject SkinGO;
	public Material SkinMaterial;
	public GameObject GunGO;
	public CharacterLevel[] Levels;
	public int CurrentLevel {get; private set;}
	public int MaxLevel { get { return Levels.Length; } }
	public int NextLevelPrice { get { return Levels[CurrentLevel+1].LevelPrice; } }

	public bool IsUpgradable { get { return (CurrentLevel < MaxLevel); } }

	public bool IsBlocked {get; private set;}

	public CharacterDescriptor ()
	{
		CurrentLevel = 0;
		IsBlocked = false;
	}

	public void Upgrade ()
	{
		if (IsUpgradable)
			CurrentLevel++;
	}

	public void Unblock ()
	{
		IsBlocked = false;
	}
}
