using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int Coins { get { return Descriptor.Coins; } }

	public PlayerDescriptor Descriptor;

	public Character SelectedChar;// { get; private set; }
	public SkinManager CharSkinManager;

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
		SelectedChar.GetComponent<CharacterMovement>().Reset();

		SelectedChar.transform.position = _InitialCharPosition;
		SelectedChar.transform.rotation = _InitialCharRotation;
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);
	}

	public void RevivePlayer ()
	{
		SelectedChar.gameObject.SetActive(false);
		SelectedChar.gameObject.SetActive(true);

		// get character movement var
		CharacterMovement cMove = SelectedChar.GetComponent<CharacterMovement>();
		cMove.StopRunning(); // Stop running
		cMove.StartRunning(); // Resume running
	}

	public void LoadGame ()
	{
		WarController war = GameController.Instance.War;
		war.SelectWar(Descriptor.SelectedWar);
		war.SelectRun(Descriptor.SelectedRun);

		CharSkinManager.AlignToDescriptor(war.CurrentRunDescriptor.Characters[Descriptor.SelectedCharacter]);
		SelectCharacter(Descriptor.SelectedCharacter);
	}

	public void SelectCharacter (int charId)
	{
		UpdateDescriptor(charId);

		CharacterDescriptor characterDescriptor = 
			GameController.Instance.War.CurrentRunDescriptor.Characters[charId];

		SelectedChar.AlignToDescriptor(characterDescriptor);
		SelectedChar.GetComponent<CharacterShooter>().AlignToDescriptor(characterDescriptor);

		GameController.Instance.Missions.SelectGun(characterDescriptor.GunType);
	}

	void UpdateDescriptor (int charId)
	{
		WarController war = GameController.Instance.War;
		Descriptor.SelectedWar = war.CurrentWarId;
		Descriptor.SelectedRun = war.CurrentRunId;
		Descriptor.SelectedCharacter = charId;
	}

	public void SelectControl (Control control)
	{
		SelectedControl = control;
		SelectedChar.CharControl = SelectedControl;
	}

	public int GetDistanceRan ()
	{
		return ((int)(SelectedChar.transform.position-_InitialCharPosition).magnitude);
	}

}
