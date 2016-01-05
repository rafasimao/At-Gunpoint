using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour 
{
	public Sounds SoundsController;
	public Image MusicBtImage, EffectAudioBtImage;
	public Sprite MusicOnSprite, MusicOffSprite, EffectsOnSprite, EffectsOffSprite;
	bool _IsMusicOn = true, _IsEffectsOn = true;

	public Languages LanguagesController;
	public Sprite[] Flags;
	public Image FlagBtImage;
	int _CurrentLanguage;

	public Control[] Controls;
	int _CurrentControl;

	void Start ()
	{
		if (PlayerPrefs.HasKey("IsMusicOn"))
			LoadPlayerPrefs();
		else
			SavePlayerPrefs();
	}

	void LoadPlayerPrefs ()
	{
		SetMusic( (PlayerPrefs.GetInt("IsMusicOn")>0) ? true : false );
		SetEffectAudio( (PlayerPrefs.GetInt("IsEffectsOn")>0) ? true : false );
		SetLanguage( PlayerPrefs.GetInt("CurrentLanguage") );
		ChoseControl( PlayerPrefs.GetInt("CurrentControl") );
	}

	void SavePlayerPrefs ()
	{
		PlayerPrefs.SetInt("IsMusicOn", (_IsMusicOn) ? 1 : 0);
		PlayerPrefs.SetInt("IsEffectsOn", (_IsEffectsOn) ? 1 : 0);
		PlayerPrefs.SetInt("CurrentLanguage",_CurrentLanguage);
		PlayerPrefs.SetInt("CurrentControl",_CurrentControl);

		PlayerPrefs.Save();
	}

	public void ChangeLanguage ()
	{
		SetLanguage(((_CurrentLanguage+1)<Flags.Length) ? _CurrentLanguage+1 : 0);
	}

	void SetLanguage (int language)
	{
		_CurrentLanguage = language;
		PlayerPrefs.SetInt("CurrentLanguage",_CurrentLanguage);
		
		LanguagesController.SelectLanguage(_CurrentLanguage);
		FlagBtImage.sprite = Flags[_CurrentLanguage];
		gameObject.SetActive(false);
		gameObject.SetActive(true);
	}

	public void ChoseControl (int control)
	{
		if (control>-1 && control<Controls.Length)
		{
			_CurrentControl = control;
			PlayerPrefs.SetInt("CurrentControl",_CurrentControl);

			SetAllControlsGOs(false);
			Controls[control].gameObject.SetActive(true);
			GameController.Instance.GamePlayer.SelectControl(Controls[control]);
		} 
	}

	void SetAllControlsGOs (bool active)
	{
		for (int i=0; i<Controls.Length; i++)
			Controls[i].gameObject.SetActive(active);
	}

	public void ToggleMusic ()
	{
		SetMusic(!_IsMusicOn);
	}

	void SetMusic (bool isOn)
	{
		_IsMusicOn = isOn;
		PlayerPrefs.SetInt("IsMusicOn", (isOn) ? 1 : 0);
		
		SoundsController.SetMusicOn(isOn);
		MusicBtImage.sprite = (isOn) ? MusicOnSprite : MusicOffSprite;
	}

	public void ToggleEffectAudio ()
	{
		SetEffectAudio(!_IsEffectsOn);
	}

	void SetEffectAudio (bool isOn)
	{
		_IsEffectsOn = isOn;
		PlayerPrefs.SetInt("IsEffectsOn", (isOn) ? 1 : 0);
		
		SoundsController.SetEffectsOn(isOn);
		EffectAudioBtImage.sprite = (isOn) ? EffectsOnSprite : EffectsOffSprite;
	}

}
