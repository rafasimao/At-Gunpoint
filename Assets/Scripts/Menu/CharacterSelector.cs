using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour 
{
	public CharSelectorView SelectorView;
	public SkinManager MainCharSkin;

	WarDescriptor _War;
	RunDescriptor _CurrentRun;

	int _CurrentCharacter;

	void Start ()
	{
		_CurrentCharacter = 0;
	}

	void OnEnable ()
	{
		AlignToDescriptor (GameController.Instance.War.CurrentWarDescriptor);
		ChangeCharacterInfos(_CurrentRun.Characters[_CurrentCharacter]);
	}

	public void AlignToDescriptor (WarDescriptor descriptor)
	{
		_War = descriptor;
		_CurrentRun = _War.Run1;
		_CurrentCharacter = 0;
	}

	public void MoveLeft ()
	{
		if (_CurrentCharacter > 0)
		{
			ChangeCharacterInfos(_CurrentRun.Characters[--_CurrentCharacter]);
		}
		else if (_CurrentRun == _War.Run2)
		{
			GameController.Instance.War.SelectRun(WarDescriptor.WarRun.Run1);
			_CurrentRun = _War.Run1;
			_CurrentCharacter = _CurrentRun.Characters.Length-1;

			ChangeCharacterInfos(_CurrentRun.Characters[_CurrentCharacter]);
		}
	}

	public void MoveRight () 
	{
		if (_CurrentCharacter < (_CurrentRun.Characters.Length-1))
		{
			ChangeCharacterInfos(_CurrentRun.Characters[++_CurrentCharacter]);
		}
		else if (_CurrentRun == _War.Run1)
		{
			GameController.Instance.War.SelectRun(WarDescriptor.WarRun.Run2);
			_CurrentRun = _War.Run2;
			_CurrentCharacter = 0;

			ChangeCharacterInfos(_CurrentRun.Characters[_CurrentCharacter]);
		}
	}

	void ChangeCharacterInfos (CharacterDescriptor character)
	{
		UpdateCharacterSkin(character);
		SelectorView.UpdateCharInformations(character);
	}

	public void UpgradeCharacter ()
	{
		Player player = GameController.Instance.GamePlayer;
		CharacterDescriptor descriptor = _CurrentRun.Characters[_CurrentCharacter];

		if (descriptor.IsUpgradable && player.SpendCoins(descriptor.NextLevelPrice))
			descriptor.Upgrade();

		SelectorView.UpdateCharInformations(_CurrentRun.Characters[_CurrentCharacter]);
	}

	void UpdateCharacterSkin (CharacterDescriptor character)
	{
		MainCharSkin.ChangeSkin(character.SkinType);
		MainCharSkin.ChangeGun(character.GunType);
	}

	public void SelectCharacter ()
	{
		GameController.Instance.GamePlayer.SelectCharacter(_CurrentRun.Characters[_CurrentCharacter]);
	}

}
