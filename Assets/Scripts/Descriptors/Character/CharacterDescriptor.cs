using UnityEngine;
using System.Collections;

public class CharacterDescriptor : ProductDescriptor
{
	public string Name;
	public Skins.Type SkinType;
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

	public int LevelNumber { get { return _CurrentLevel+1; } }
	public int NumberOfLevels { get { return Levels.Length; } }

	public CharacterLevel Level { get { return Levels[_CurrentLevel]; } }
	public CharacterLevel LastLevel { get { return Levels[NumberOfLevels-1]; } }

	public int _CurrentLevel;

	public int NextLevelPrice 
	{ 
		get 
		{ 
			return (_CurrentLevel < NumberOfLevels-1) ? Levels[_CurrentLevel+1].LevelPrice : -1; 
		}
	}

	public bool IsUpgradable { get { return (_CurrentLevel < (NumberOfLevels-1)); } }

	public void Upgrade ()
	{
		if (IsUpgradable)
			_CurrentLevel++;
	}

	public void LoadData (CharacterData data)
	{
		_IsLocked = data.IsLocked;
		_CurrentLevel = data.CurrentLevel;
	}

}
