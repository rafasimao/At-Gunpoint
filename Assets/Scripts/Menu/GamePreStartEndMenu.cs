using UnityEngine;
using System.Collections;

public class GamePreStartEndMenu : MonoBehaviour 
{

	public TimerSwitcher Switcher;
	public Items.Item ItemType;
	public GameObject TitleText;
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
			if (Items.IsItemReady(ItemType))
			{
				TitleText.SetActive(true);
				EnableItemButton(ItemBt, ItemType);
				ItemVideoBt.SetActive(GameController.Instance.Ads.IsRewardedAdReady());
			}
			else
			{
				SetAllOff();
			}
		}
	}

	void EnableItemButton (GameObject bt, Items.Item item)
	{
		bt.SetActive(_GamePlayer.GetNumberOfOwnItems(item) > 0 ||
		             _GamePlayer.Coins >= Items.GetItemPrice(item));
	}

	void SetAllOff()
	{
		TitleText.SetActive(false);
		ItemBt.SetActive(false);
		ItemVideoBt.SetActive(false);
	}

	public void UseCheckpoint ()
	{
		if (OwnsOrBuy(Items.Item.Checkpoint))
		{
			if (Items.UseItem(Items.Item.Checkpoint))
			{
				SetAllOff();
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

	public void UseCheckpointVideo ()
	{
		GameController.Instance.Ads.ShowRewardedAd(CheckpointVideoCallBack);
	}

	public void UseRevivalVideo ()
	{
		GameController.Instance.Ads.ShowRewardedAd(RevivalVideoCallBack);	
	}

	public void CheckpointVideoCallBack (bool finished)
	{
		if (GetFreeItem(Items.Item.Checkpoint, finished))
			UseCheckpoint();
	}

	public void RevivalVideoCallBack (bool finished)
	{
		if (GetFreeItem(Items.Item.Revival, finished))
			UseRevival();
	}

	bool GetFreeItem (Items.Item item, bool sawVideo)
	{
		if (sawVideo)
		{
			_GamePlayer.CollectCoins(Items.GetItemPrice(item));
			_GamePlayer.BuyItem(item);
		}
		return sawVideo;
	}

	bool OwnsOrBuy (Items.Item item)
	{
		return (_GamePlayer.GetNumberOfOwnItems(item) > 0 || _GamePlayer.BuyItem(item));
	}

}
