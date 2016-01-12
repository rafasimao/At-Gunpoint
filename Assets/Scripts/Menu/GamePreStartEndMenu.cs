using UnityEngine;
using System.Collections;

public class GamePreStartEndMenu : MonoBehaviour 
{

	public TimerSwitcher Switcher;
	public GameObject CheckpointBt, RevivalBt;

	Player _GamePlayer;

	void OnEnable ()
	{
		if (_GamePlayer==null)
			_GamePlayer = GameController.Instance.GamePlayer;

		if (PlayerTracer.ReachedBoss())
			Switcher.Activate();
		else
		{
			EnableItemButton(CheckpointBt, Items.Item.Checkpoint);
			EnableItemButton(RevivalBt, Items.Item.Revival);
		}
	}

	void EnableItemButton (GameObject bt, Items.Item item)
	{
		bt.SetActive(_GamePlayer.GetNumberOfOwnItems(item) > 0 ||
		             _GamePlayer.Coins >= Items.GetItemPrice(item));
	}

	public void UseCheckpoint ()
	{
		if (OwnsOrBuy(Items.Item.Checkpoint))
		{
			if (Items.UseItem(Items.Item.Checkpoint))
				gameObject.SetActive(false);
		}
	}

	public void UseRevival ()
	{
		if (OwnsOrBuy(Items.Item.Revival))
		{
			if (Items.UseItem(Items.Item.Revival))
			{
				gameObject.SetActive(false);
				Switcher.Deactivate();
			}
		}
	}

	bool OwnsOrBuy (Items.Item item)
	{
		return (_GamePlayer.GetNumberOfOwnItems(item) > 0 || _GamePlayer.BuyItem(item));
	}

}
