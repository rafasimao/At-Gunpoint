using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour 
{

	public enum Item 
	{
		Checkpoint=0,
		Revival=1
	}

	const int _NumberOfItems = 2;

	[SerializeField]
	int[] _ItemsPrices;

	#region Singleton:
	static Items _Instance;
	
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(_Instance != null && _Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		_Instance = this;
	}
	#endregion

	public static int GetNumberOfItems ()
	{
		return _NumberOfItems;
	}

	public static int GetItemPrice (Item item)
	{
		return (_Instance!=null) ? _Instance._ItemsPrices[(int)item] : 9999;
	}


	public static bool UseItem (Item item)
	{
		bool canUseItem = GameController.Instance.GamePlayer.UseItem(item);

		if (canUseItem)
		{
			switch (item)
			{
			case Item.Checkpoint:
				_Instance.UseCheckpoint();
				break;
			case Item.Revival:
				_Instance.UseRevival();
				break;
			}
		}

		return canUseItem;
	}

	public static bool IsItemReady (Item item)
	{
		bool result = true;
		switch (item)
		{
		case Item.Checkpoint:
			result = GameController.Instance.Map.HasCheckpoint();
			break;
		case Item.Revival:
			break;
		}

		return result;
	}

	void UseCheckpoint ()
	{
		//GameController.Instance.Map.SaveCheckpoint();
		GameController.Instance.Map.LoadCheckpoint();
	}

	void UseRevival ()
	{
		GameController.Instance.GamePlayer.RevivePlayer();
	}

}
