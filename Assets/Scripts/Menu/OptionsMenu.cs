using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour 
{

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

}
