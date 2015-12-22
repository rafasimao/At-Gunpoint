using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarView : MonoBehaviour 
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
		LockView.SetActive(false);
	}

	public void BuyUnlock ()
	{
		_War.Unlock(); // The warDescriptor tries to buy its unlock
		if (!_War.IsLocked)
			UnlockWar();
	}

}
