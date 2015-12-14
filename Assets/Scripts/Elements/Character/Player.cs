using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int Coins { get; private set; }
	public int Emeralds { get; private set; }

	public int[] ItemsOwn { get; private set; }

	public Character SelectedChar;// { get; private set; }
	public Control SelectedControl;// { get; private set; }

	Vector3 _InitialCharPosition;
	Quaternion _InitialCharRotation;

	void Start ()
	{
		Coins = 10000;//4now

		ItemsOwn = new int[Items.GetNumberOfItems()];

		_InitialCharPosition = SelectedChar.transform.position;
		_InitialCharRotation = SelectedChar.transform.rotation;
	}

	public void CollectCoins (int coins)
	{
		Coins += coins;
	}

	public bool SpendCoins (int coins)
	{
		bool spent = (Coins >= coins);
		if (spent)
			Coins -= coins;

		return spent;
	}

	public void CollectEmeralds (int emeralds)
	{
		Emeralds += emeralds;
	}

	public bool SpendEmeralds (int emeralds)
	{
		bool spent = (Emeralds >= emeralds);
		if (spent)
			Emeralds -= emeralds;
		return spent;
	}

	public bool UseItem (Items.Item item)
	{
		bool used = (ItemsOwn[(int)item] > 0);
		if (used)
			ItemsOwn[(int)item]--;
		return used;
	}

	public void BuyItem (int item)
	{
		bool bought = (item>-1 && item<ItemsOwn.Length && SpendCoins(Items.GetItemPrice((Items.Item)item)));
		if (bought)
			ItemsOwn[item]++;
		//return bought;
	}


	public void StartRun ()
	{
		SelectedChar.GetComponent<CharacterMovement>().StartRunning();
		PlayerTracer.StartRun();
	}

	public void ResetPlayerCharacter ()
	{
		SelectedChar.transform.position = _InitialCharPosition;
		SelectedChar.transform.rotation = _InitialCharRotation;
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);

		StopRun();
	}

	public void RevivePlayer ()
	{
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);

		StopRun();
		StartRun();
	}

	public void StopRun ()
	{
		SelectedChar.GetComponent<CharacterMovement>().StopRunning();
	}

	public void SelectCharacter (CharacterDescriptor characterDescriptor)
	{
		SelectedChar.AlignToDescriptor(characterDescriptor);
		SelectedChar.GetComponent<CharacterShooter>().AlignToDescriptor(characterDescriptor);

		GameController.Instance.Missions.SelectGun(characterDescriptor.GunType);
		//IntegrateCharacterAndControl();
	}

	public void SelectControl (Control control)
	{
		if (SelectedControl != null)
			Destroy(SelectedControl.gameObject);
		SelectedControl = control;
		IntegrateCharacterAndControl();
	}

	void IntegrateCharacterAndControl ()
	{
		SelectedChar.CharControl = SelectedControl;
		SelectedControl.Movement = SelectedChar.GetComponent<CharacterMovement>();
		SelectedControl.Shooter = SelectedChar.GetComponent<CharacterShooter>();
	}

	public int GetDistanceRan ()
	{
		return ((int)(SelectedChar.transform.position-_InitialCharPosition).magnitude);
	}

}
