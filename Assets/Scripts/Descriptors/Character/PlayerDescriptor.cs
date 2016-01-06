using UnityEngine;
using System.Collections;

public class PlayerDescriptor : ScriptableObject
{
	[SerializeField]
	int _Coins;
	public int Coins { get { return _Coins; } }

	[SerializeField]
	int[] _ItemsOwn;
	public int[] ItemsOwn { get { return _ItemsOwn; } }

	public int SelectedWar, SelectedCharacter;
	public WarDescriptor.WarRun SelectedRun;

	void OnEnable ()
	{
		_ItemsOwn = new int[Items.GetNumberOfItems()];
	}

	public void CollectCoins (int coins)
	{
		_Coins += coins;
	}
	
	public bool SpendCoins (int coins)
	{
		bool spent = (_Coins >= coins);
		if (spent)
			_Coins -= coins;
		
		return spent;
	}

	public bool UseItem (Items.Item item)
	{
		bool used = (_ItemsOwn[(int)item] > 0);
		if (used)
			_ItemsOwn[(int)item]--;
		return used;
	}
	
	public bool BuyItem (Items.Item item)
	{
		bool bought = SpendCoins(Items.GetItemPrice(item));
		if (bought)
			_ItemsOwn[(int)item]++;
		return bought;
	}
	
	public int GetNumberOfOwnItems (Items.Item item)
	{
		return _ItemsOwn[(int)item];
	}

	public void LoadData (PlayerData data)
	{
		_Coins = data.Coins;
		SelectedWar = data.SelectedWar;
		SelectedRun = (WarDescriptor.WarRun)data.SelectedRun;
		SelectedCharacter = data.SelectedCharacter;

		for (int i=0; i<data.ItemsOwn.Count; i++)
			_ItemsOwn[i] = data.ItemsOwn[i];
	}

}
