using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlsView : MonoBehaviour 
{
	public OptionsMenu OptMenu;
	public Button TapBt, SwipeBt;

	void OnEnable ()
	{
		if (OptMenu.CurrentControl==0)
		{
			TapBt.interactable = false; // TapBt is selected
			SwipeBt.interactable = true;
		}
		else if (OptMenu.CurrentControl==1)
		{
			TapBt.interactable = true;
			SwipeBt.interactable = false; // SwipeBt is Selected
		}
	}

}
