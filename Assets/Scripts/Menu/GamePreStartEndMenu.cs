using UnityEngine;
using System.Collections;

public class GamePreStartEndMenu : MonoBehaviour 
{

	public TimerSwitcher Switcher;
	public Items.Item ItemType;
	public GameObject ItemBt, ItemVideoBt;

	public bool IsEnd;

	Player _GamePlayer;

	void OnEnable ()
	{
		if (_GamePlayer==null)
			_GamePlayer = GameController.Instance.GamePlayer;

		if (IsEnd && PlayerTracer.ReachedBoss())
			Switcher.Activate();
		else
		{
			EnableItemButton(ItemBt, ItemType);
			EnableItemButton(ItemVideoBt, ItemType);
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
			{
				//gameObject.SetActive(false);
				ItemBt.SetActive(false);
				ItemVideoBt.SetActive(false);
			}
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
