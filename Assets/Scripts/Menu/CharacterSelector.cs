using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour 
{
	public CharSelectorView SelectorView;
	public Renderer CharacterBaseRenderer;
	public CharacterDescriptor[] CharactersDescriptors;

	int CurrentCharacter;

	void Start ()
	{
		CurrentCharacter = 0;
	}

	void OnEnable ()
	{
		SelectorView.UpdateCharInformations(CharactersDescriptors[CurrentCharacter]);
	}

	public void AlignToDescriptor (WarDescriptor descriptor)
	{

	}

	public void MoveLeft ()
	{
		if (CurrentCharacter > 0)
		{
			UpdateCharacterSkin(CharactersDescriptors[CurrentCharacter],
			                    CharactersDescriptors[--CurrentCharacter]);
			SelectorView.UpdateCharInformations(CharactersDescriptors[CurrentCharacter]);
		}
	}

	public void MoveRight () 
	{
		if (CurrentCharacter < (CharactersDescriptors.Length-1))
		{
			UpdateCharacterSkin(CharactersDescriptors[CurrentCharacter],
			                    CharactersDescriptors[++CurrentCharacter]);
			SelectorView.UpdateCharInformations(CharactersDescriptors[CurrentCharacter]);
		}
	}

	public void UpgradeCharacter ()
	{
		Player player = GameController.Instance.GamePlayer;
		CharacterDescriptor descriptor = CharactersDescriptors[CurrentCharacter];

		if (descriptor.IsUpgradable && player.SpendCoins(descriptor.NextLevelPrice))
			descriptor.Upgrade();

		SelectorView.UpdateCharInformations(CharactersDescriptors[CurrentCharacter]);
	}

	void UpdateCharacterSkin (CharacterDescriptor previous, CharacterDescriptor current)
	{
		ActivateGO(previous.SkinGO, false);
		ActivateGO(previous.GunGO, false);
		ActivateGO(current.SkinGO, true);
		ActivateGO(current.GunGO, true);

		CharacterBaseRenderer.material = current.SkinMaterial;
	}

	void ActivateGO (GameObject go, bool active)
	{
		if (go != null)
			go.SetActive(active);
	}

	public void SelectCharacter ()
	{
		GameController.Instance.GamePlayer.SelectCharacter(CharactersDescriptors[CurrentCharacter]);
	}

}
