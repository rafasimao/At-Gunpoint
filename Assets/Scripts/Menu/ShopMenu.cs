using UnityEngine;
using System.Collections;

public class ShopMenu : MonoBehaviour
{
	Player _GamePlayer;

	void Start ()
	{
		_GamePlayer = GameController.Instance.GamePlayer;
	}

	public void BuyCheckpoint ()
	{
		_GamePlayer.BuyItem(Items.Item.Checkpoint);
	}

	public void BuyRevival () 
	{
		_GamePlayer.BuyItem(Items.Item.Revival);
	}

}
