using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int Coins { get; private set; }
	public int Emeralds { get; private set; }

	public Character SelectedChar;// { get; private set; }

	public Control SelectedControl;// { get; private set; }

	public void CollectCoins (int coins)
	{
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

	public void SelectCharacter (Character character)
	{
		if (SelectedChar != null)
			Destroy(SelectedChar.gameObject);
		SelectedChar = character;
		SelectedChar.transform.parent = transform;
		IntegrateCharacterAndControl();
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

}
