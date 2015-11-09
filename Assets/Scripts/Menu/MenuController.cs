using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{

	const int _MAINMENU_MODE = 0;
	const int _CHARSELECTION_MODE = 1;
	const int _OPTIONS_MODE = 2;
	const int _RUNNING_MODE = 3;
	const int _INACTIVE_MODE = 4;

	public GameObject MainMenu, CharSelection, Options, Running;

	void Start () 
	{
		SetMode(_MAINMENU_MODE);
	}

	public void GoToMode (int mode)
	{
		SetMode(mode);
	}

	void SetMode (int mode)
	{
		switch (mode)
		{
		case _MAINMENU_MODE:
			SetActiveViews (true, false, false, false);
			break;
		case _CHARSELECTION_MODE:
			SetActiveViews (false, true, false, false);
			break;
		case _OPTIONS_MODE:
			SetActiveViews (false, false, true, false);
			break;
		case _RUNNING_MODE:
			SetActiveViews(false, false, false, true);
			break;
		case _INACTIVE_MODE:
			SetActiveViews(false, false, false, false);
			break;
		default:
			return;
		}
	}

	void SetActiveViews (bool mainMenu, bool charSelection, bool options, bool running)
	{
		MainMenu.SetActive(mainMenu);
		CharSelection.SetActive(charSelection);
		Options.SetActive(options);
		Running.SetActive(running);
	}
}
