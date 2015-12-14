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


	public void UseItem (int item)
	{
		if (item>-1 && item<GetNumberOfItems())
		{
			Item it = (Item)item;
			
			if (GameController.Instance.GamePlayer.UseItem(it))
			{
				switch (it)
				{
				case Item.Checkpoint:
					UseCheckpoint();
					break;
				case Item.Revival:
					UseRevival();
					break;
				}
			}
		}
	}

	void UseCheckpoint ()
	{
		GameController.Instance.Map.SaveCheckpoint();
	}

	void UseRevival ()
	{
		GameController.Instance.GamePlayer.RevivePlayer();
	}

}
