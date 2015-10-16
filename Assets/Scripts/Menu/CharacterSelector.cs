using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour 
{

	public CharacterDescriptor[] CharactersDescriptors;

	int CurrentCharacter;

	void Start ()
	{
		CurrentCharacter = 0;
	}

	public void MoveLeft ()
	{
		if (CurrentCharacter > 0)
			CurrentCharacter--;
	}

	public void MoveRight () 
	{
		if (CurrentCharacter < (CharactersDescriptors.Length-1))
			CurrentCharacter++;
	}

	public void UpgradeCharacter ()
	{
		Player player = GameController.Instance.GamePlayer;
		CharacterDescriptor descriptor = CharactersDescriptors[CurrentCharacter];

		if (descriptor.IsUpgradable && player.SpendCoins(descriptor.NextLevelPrice))
			descriptor.Upgrade();
	}


	public void SelectCharacter ()
	{
		Character c = GeneralFabric.CreateObject<Character>(
			CharactersDescriptors[CurrentCharacter].CharacterPrefab, null);
		GameController.Instance.SelectNewCharacter(c);
	}

}
