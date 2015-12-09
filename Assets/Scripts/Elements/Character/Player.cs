using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int Coins { get; private set; }
	public int Emeralds { get; private set; }

	public Character SelectedChar;// { get; private set; }
	public Control SelectedControl;// { get; private set; }

	public PlayerTracer Tracer;

	Vector3 _InitialCharPosition;
	Quaternion _InitialCharRotation;

	void Start ()
	{
		Coins = 10000;

		_InitialCharPosition = SelectedChar.transform.position;
		_InitialCharRotation = SelectedChar.transform.rotation;
	}

	public void CollectCoins (int coins)
	{
		Tracer.CollectedCoin();
		Coins += coins;
	}

	public bool SpendCoins (int coins)
	{
		if (Coins >= coins)
		{
			Coins -= coins;
			return true;
		}
		return false;
	}

	public void CollectEmeralds (int emeralds)
	{
		Emeralds += emeralds;
	}

	public bool SpendEmeralds (int emeralds)
	{
		if (Emeralds >= emeralds)
		{
			Emeralds -= emeralds;
			return true;
		}
		return false;
	}

	public void StartRun ()
	{
		SelectedChar.GetComponent<CharacterMovement>().StartRunning();

		if (Tracer!=null)
			Tracer.StartRun();
	}

	public void ResetPlayerCharacter ()
	{
		SelectedChar.transform.position = _InitialCharPosition;
		SelectedChar.transform.rotation = _InitialCharRotation;
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);

		StopRun();
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
