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

	public void ChangeLanguage ()
	{
		_CurrentLanguage = ((_CurrentLanguage+1)<Flags.Length) ? _CurrentLanguage+1 : 0;
		LanguagesController.SelectLanguage(_CurrentLanguage);
		FlagBtImage.sprite = Flags[_CurrentLanguage];
		gameObject.SetActive(false);
		gameObject.SetActive(true);
	}

	public void ChoseControl (int control)
	{
		if (control>-1 && control<Controls.Length)
		{
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
		_IsMusicOn = !_IsMusicOn;
		SoundsController.SetMusicOn(_IsMusicOn);
		MusicBtImage.sprite = (_IsMusicOn) ? MusicOnSprite : MusicOffSprite;
	}

	public void ToggleEffectAudio ()
	{
		_IsEffectsOn = !_IsEffectsOn;
		SoundsController.SetEffectsOn(_IsEffectsOn);
		EffectAudioBtImage.sprite = (_IsEffectsOn) ? EffectsOnSprite : EffectsOffSprite;
	}

}
