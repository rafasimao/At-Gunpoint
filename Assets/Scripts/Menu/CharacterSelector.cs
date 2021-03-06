﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelector : MonoBehaviour 
{
	public CharSelectorView SelectorView;
	public SkinManager MainCharSkin;
	public MissionsButtonView MissionBt; 

	public Button LeftChoser, RightChoser;

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
		MissionBt.UpdateImage();

		VerifySideButtons();
	}

	public void AlignToDescriptor (WarDescriptor descriptor)
	{
		_War = descriptor;
		_CurrentRun = GameController.Instance.War.CurrentRunDescriptor;
		_CurrentCharacter = 0;
	}

	public void MoveLeft ()
	{
		if (_CurrentCharacter > 0)
			ChangeCharacterInfos(_CurrentRun.Characters[--_CurrentCharacter]);

		else if (_CurrentRun == _War.Run2)
			ChangeToRun(WarDescriptor.WarRun.Run1, _War.Run1.Characters.Length-1);

		VerifySideButtons();
	}

	public void MoveRight () 
	{
		if (_CurrentCharacter < (_CurrentRun.Characters.Length-1))
			ChangeCharacterInfos(_CurrentRun.Characters[++_CurrentCharacter]);

		else if (_CurrentRun == _War.Run1)
			ChangeToRun(WarDescriptor.WarRun.Run2, 0);

		VerifySideButtons();
	}

	void VerifySideButtons () 
	{
		LeftChoser.interactable = !(_CurrentCharacter == 0 && _CurrentRun == _War.Run1);
		RightChoser.interactable = 
			!(_CurrentCharacter == (_CurrentRun.Characters.Length-1) && _CurrentRun == _War.Run2);
	}

	void ChangeToRun (WarDescriptor.WarRun warRun, int currentChar)
	{
		GameController.Instance.War.SelectRun(warRun);
		_CurrentRun = _War.GetRun(warRun);
		_CurrentCharacter = currentChar;
		
		ChangeCharacterInfos(_CurrentRun.Characters[_CurrentCharacter]);
		MissionBt.UpdateImage();
	}

	void ChangeCharacterInfos (CharacterDescriptor character)
	{
		MainCharSkin.AlignToDescriptor(character);
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

	public void SelectCharacter ()
	{
		//GameController.Instance.GamePlayer.SelectCharacter(_CurrentRun.Characters[_CurrentCharacter]);
		GameController.Instance.GamePlayer.SelectCharacter(_CurrentCharacter);
	}

}
