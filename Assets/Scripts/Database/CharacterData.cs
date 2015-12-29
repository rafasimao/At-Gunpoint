using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterData
{
	public int CurrentLevel;
	public bool IsLocked;

	public CharacterData ()
	{
		CurrentLevel = 0;
		IsLocked = false;
	}

	public void FetchData (CharacterDescriptor character)
	{
		CurrentLevel = character.LevelNumber-1;
		IsLocked = character.IsLocked;
	}

}
