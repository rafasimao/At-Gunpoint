using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
	public PlayerData Player;
	public List<WarData> Wars;

	public GameData ()
	{
		Player = new PlayerData();
		Wars = new List<WarData>();
	}

	public void FetchData (PlayerDescriptor player, WarDescriptor[] wars)
	{
		Player.FetchData(player);

		for (int i=0; i<wars.Length; i++)
		{
			Wars.Add(new WarData());
			Wars[i].FetchData(wars[i]);
		}
	}

}
