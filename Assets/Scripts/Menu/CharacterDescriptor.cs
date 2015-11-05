using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterDescriptor
{
	public string Name;
	public GameObject SkinGO;
	public Material SkinMaterial;
	public GameObject GunGO;
	public Guns.Types GunType;
	public CharacterLevel[] Levels;

	public GunDescriptor Gun { get { return Guns.GetGunDescriptor(GunType); } }
	public GunLevel GunLevel 
	{
		get 
		{
			return (Level.GunLevelNumber>0 && Level.GunLevelNumber<=Gun.NumberOfLevels) ?
				Gun.Levels[Level.GunLevelNumber-1] : null; 
		} 
	}

	public int LevelNumber {get { return CurrentLevel+1; } }
	public int NumberOfLevels { get { return Levels.Length; } }

	public CharacterLevel Level { get { return Levels[CurrentLevel]; } }
	public CharacterLevel LastLevel { get { return Levels[NumberOfLevels-1]; } }

	int CurrentLevel;

	public int NextLevelPrice 
	{ 
		get 
		{ 
			return (CurrentLevel < NumberOfLevels-1) ? Levels[CurrentLevel+1].LevelPrice : -1; 
		}
	}

	public bool IsUpgradable { get { return (CurrentLevel < (NumberOfLevels-1)); } }

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
