using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour 
{
	public Control[] Controls;

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
