using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
	public int Coins;
	public int SelectedWar, SelectedCharacter;
	public List<int> ItemsOwn;

	public PlayerData ()
	{
		Coins = SelectedWar = SelectedCharacter =0;
		ItemsOwn = new List<int>();
	}

	public void FetchData (PlayerDescriptor player)
	{
		Coins = player.Coins;
		SelectedWar = player.SelectedWar;
		SelectedCharacter = player.SelectedCharacter;

		for (int i=0; i<player.ItemsOwn.Length; i++)
			ItemsOwn.Add(player.ItemsOwn[i]);
	}
}
