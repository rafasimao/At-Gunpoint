using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class DataController : MonoBehaviour
{

	string DataPath = "/Save.dat";

	void Start ()
	{
		Load();
	}

	void OnDestroy ()
	{
		Save();
	}

	void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + DataPath);
		bf.Serialize(file, FetchGameData());
		file.Close();
	}

	GameData FetchGameData ()
	{
		GameData data = new GameData();
		data.FetchData(GameController.Instance.GamePlayer.Descriptor, 
		               GameController.Instance.War.GetWars());

		return data;
	}

	void Load ()
	{
		if (File.Exists(Application.persistentDataPath + DataPath)) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + DataPath, FileMode.Open);
			GameData data = (GameData)bf.Deserialize(file);
			file.Close();

			LoadPlayerData(data);
			LoadWarsData(data);
		}
	}

	void LoadPlayerData (GameData data)
	{
		GameController.Instance.GamePlayer.Descriptor.LoadData(data.Player);
	}

	void LoadWarsData (GameData data)
	{
		WarDescriptor[] wars = GameController.Instance.War.GetWars();
		for (int i=0; i<wars.Length; i++)
			wars[i].LoadData(data.Wars[i]);
	}

	void ShowGameData (GameData data)
	{
		string msg = "";

		msg = "GameData:\n" +
			" - PlayerData: \n";

		for (int i=0; i<data.Wars.Count; i++)
		{
			msg += " - WarsData:\n" +
				"IsLocked: " + data.Wars[i].IsLocked + 
				"\n - - Run1:\n";
			msg += ShowRunData(data.Wars[i].Run1);
			msg += " - - Run2:\n";
			msg += ShowRunData(data.Wars[i].Run2);
		}

		Debug.Log(msg);
	}

	string ShowRunData (RunData data)
	{
		string msg;

		msg = "CheckpointZone: " + data.CheckpointZone + "\n" +
			" - - - MissionsFamilySetData:\n" + 
			"Counter: " + data.MissionsFamilySet.Counter  + "\n";
		for (int i=0; i<data.MissionsFamilySet.MissionsSets.Count; i++)
		{
			msg += " MissionsSet" + i + " :\n";
			msg += ShowMissionsData(data.MissionsFamilySet.MissionsSets[i]);
		}

		msg += " - - - CharactersData:\n";
		for (int i=0; i<data.Characters.Count; i++)
		{
			msg += " Char" + i + " :\n";
			msg += ShowCharacterData(data.Characters[i]);
		}

		return msg;
	}

	string ShowMissionsData (MissionsSetData data)
	{
		string msg = "";

		for (int i=0; i<data.Missions.Count; i++)
		{
			msg += " Mission" + i + " :\n" +
				"Counter: " + data.Missions[i].Counter + "\n";
		}

		return msg;
	}

	string ShowCharacterData (CharacterData data)
	{
		return "CurrentLevel: " + data.CurrentLevel +
			"\nIsLocked: " + data.IsLocked + "\n";
	}
}



