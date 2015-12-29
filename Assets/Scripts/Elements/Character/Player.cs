using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int Coins { get { return Descriptor.Coins; } }

	public PlayerDescriptor Descriptor;

	public Character SelectedChar;// { get; private set; }
	public Control SelectedControl;// { get; private set; }

	Vector3 _InitialCharPosition;
	Quaternion _InitialCharRotation;

	void Start ()
	{
		_InitialCharPosition = SelectedChar.transform.position;
		_InitialCharRotation = SelectedChar.transform.rotation;
	}

	public void CollectCoins (int coins)
	{
		Descriptor.CollectCoins(coins);
	}
	
	public bool SpendCoins (int coins)
	{
		return Descriptor.SpendCoins(coins);
	}

	public bool UseItem (Items.Item item)
	{
		return Descriptor.UseItem(item);
	}

	public bool BuyItem (Items.Item item)
	{
		return Descriptor.BuyItem(item);
	}

	public int GetNumberOfOwnItems (Items.Item item)
	{
		return Descriptor.GetNumberOfOwnItems(item);
	}


	public void StartRun ()
	{
		SelectedChar.GetComponent<CharacterMovement>().StartRunning();
		PlayerTracer.StartRun();
	}

	public void ResetPlayerCharacter ()
	{
		StopRun();

		SelectedChar.transform.position = _InitialCharPosition;
		SelectedChar.transform.rotation = _InitialCharRotation;
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);
	}

	public void RevivePlayer ()
	{
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);

		StopRun();
		ResumeRun();
	}

	public void StopRun ()
	{
		//SelectedChar.GetComponent<CharacterMovement>().StopRunning();
		SelectedChar.GetComponent<CharacterMovement>().Reset();
	}

	public void ResumeRun ()
	{
		SelectedChar.GetComponent<CharacterMovement>().StartRunning();
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
		SelectedControl = control;
		IntegrateCharacterAndControl();
	}

	void IntegrateCharacterAndControl ()
	{
		SelectedChar.CharControl = SelectedControl;
		//SelectedControl.Movement = SelectedChar.GetComponent<CharacterMovement>();
		//SelectedControl.Shooter = SelectedChar.GetComponent<CharacterShooter>();
	}

	public int GetDistanceRan ()
	{
		return ((int)(SelectedChar.transform.position-_InitialCharPosition).magnitude);
	}

}
