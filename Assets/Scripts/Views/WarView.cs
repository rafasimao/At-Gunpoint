using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarView : MonoBehaviour, IPurchaseCaller
{
	public int WarNumber;

	public Button SelectWarBt;
	public GameObject LockView;
	public Text LockPriceText;

	WarDescriptor _War;

	void Start ()
	{
		_War = GameController.Instance.War.GetWar(WarNumber);
		if (_War.IsLocked)
			LockWar();
		else
			UnlockWar();
	}

	void LockWar ()
	{
		SelectWarBt.interactable = false;
		LockView.SetActive(true);
		LockPriceText.text = ""+_War.UnlockPrice;
	}

	void UnlockWar () 
	{
		SelectWarBt.interactable = true;
		if (LockView!=null)
			LockView.SetActive(false);
	}

	public void BuyUnlock ()
	{
		_War.Unlock(); // The warDescriptor tries to buy its unlock
		if (!_War.IsLocked)
			UnlockWar();
	}

	public void BuyUnlockWithCash ()
	{
		GameController.Instance.GamePurchaser.BuyWar(_War.ID, this);
	}


	// IPurchaseCaller
	public void OnPurchaseEnd()
	{
		if (_War.IsLocked)
			LockWar();
		else
			UnlockWar();
	}

}
